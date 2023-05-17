using System.Globalization;
using System.Security.Claims;
using BLL.Data;
using BLL.Data.Employee;
using BLL.Data.Employee.Reservation;
using BLL.Data.Floor;
using BLL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

[Authorize]
[Route("Selection")]
public class SelectionController : BaseController<SelectionController>
{
    private readonly IEmployeeService _employeeService;
    private readonly IFloorService _floorService;
    private readonly ILocationService _locationService;
    private readonly IReservationService _reservationService;
    private readonly IWorkspaceService _workspaceService;

    public SelectionController(ILocationService locationService, IFloorService floorService,
        IWorkspaceService workspaceService, IEmployeeService employeeService,
        IReservationService reservationService)
    {
        _locationService = locationService;
        _floorService = floorService;
        _workspaceService = workspaceService;
        _employeeService = employeeService;
        _reservationService = reservationService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        Guid employeeId = new(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString());
        List<EmployeeModel> employeeModels = new()
            { new EmployeeModel(_employeeService.GetEmployeeById(employeeId)) };

        List<LocationModel> locationModels =
            _locationService.GetAllLocations().Select(LocationModel.FromLocation).ToList();

        List<FloorModel> floorModels =
            _floorService.GetAllFloorsByLocationId(locationModels[0].Id).Select(FloorModel.FromFloor).ToList();


        DateTimeSelectionModel dateTimeSelectionModel = new()
        {
            Date = DateTime.Now,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(1)
        };

        Floor? selectedFloor = _floorService.GetFloorWithRoomsAndWorkspacesWithOccupancyById(floorModels[0].Id,
            dateTimeSelectionModel.StartTime, dateTimeSelectionModel.EndTime);

        List<WorkspacePropModel> workspaceModels =
            _workspaceService.GetWorkspacesWithCharacteristicsAndReservationsByFloorId(floorModels[0].Id)
                .Select(w =>
                    WorkspacePropModel.FromWorkspaceWithOccupied(w, dateTimeSelectionModel.StartTime,
                        dateTimeSelectionModel.EndTime))
                .ToList();

        SelectionModel model = new()
        {
            EmployeeModels = employeeModels,
            LocationModels = locationModels,
            FloorModels = floorModels,
            WorkspaceModels = workspaceModels,
            DateTimeSelectionModel = dateTimeSelectionModel,
            SelectedFloor = selectedFloor
        };

        return View(model);
    }

    [HttpPost]
    [Route("")]
    public IActionResult Selection(SelectionModel model)
    {
        model.LocationModels =
            _locationService.GetAllLocations().Select(LocationModel.FromLocation).ToList();

        model.FloorModels =
            _floorService.GetAllFloorsByLocationId(model.SelectedLocationId).Select(FloorModel.FromFloor).ToList();

        model.SelectedFloorId = model.SelectedFloorId == Guid.Empty ? model.FloorModels[0].Id : model.SelectedFloorId;

        DateTime startDate = DateTime.ParseExact(model.DateTimeSelectionModel.Date.ToString("yyyy-MM-dd") + " " +
                                                 model.DateTimeSelectionModel.StartTime.ToString("HH:mm:ss"),
            "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        DateTime endDate = DateTime.ParseExact(model.DateTimeSelectionModel.Date.ToString("yyyy-MM-dd") + " " +
                                               model.DateTimeSelectionModel.EndTime.ToString("HH:mm:ss"),
            "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        model.SelectedFloor = _floorService.GetFloorWithRoomsAndWorkspacesWithOccupancyById(model.SelectedFloorId,
            startDate, endDate);

        model.WorkspaceModels =
            _workspaceService.GetWorkspacesWithCharacteristicsAndReservationsByFloorId(model.SelectedFloorId)
                .Select(w => WorkspacePropModel.FromWorkspaceWithOccupied(w, startDate, endDate))
                .ToList();

        if (model.ReservationIsDone)
        {
            List<string> dataTransferList = model.Reservations
                .Where(x => x.Key != string.Empty && x.Key != null)
                .Where(x => x.Value != string.Empty && x.Value != null)
                .Select(x => x.Key + ":" + x.Value).ToList();

            TempData["reservationModel"] = dataTransferList.Aggregate((x, y) => x + "," + y);

            TempData["date"] = model.DateTimeSelectionModel.Date.ToString("yyyy-MM-dd HH:mm:ss");
            TempData["startTime"] = model.DateTimeSelectionModel.StartTime.ToString("HH:mm:ss");
            TempData["endTime"] = model.DateTimeSelectionModel.EndTime.ToString("HH:mm:ss");


            return RedirectToAction("Reserve");
        }

        return View("Index", model);
    }

    [HttpGet]
    [Route("Reserve")]
    public IActionResult Reserve(ReservationModel model)
    {
        string dataTransferString = TempData["reservationModel"] as string;
        DateTime date = DateTime.ParseExact(TempData["date"] as string, "yyyy-MM-dd HH:mm:ss",
            CultureInfo.InvariantCulture);
        TimeSpan startTime = TimeSpan.Parse(TempData["startTime"].ToString());
        TimeSpan endTime = TimeSpan.Parse(TempData["endTime"].ToString());

        DateTime startDate = date.Add(startTime);
        DateTime endDate = date.Add(endTime);

        if (dataTransferString != null)
        {
            List<string> dataTransferList = dataTransferString.Split(",").ToList();

            model.Reservations = dataTransferList
                .ToDictionary(
                    x => _workspaceService.GetWorkspaceById(new Guid(x.Split(":")[0])),
                    x => _employeeService.GetEmployeeById(new Guid(x.Split(":")[1])));
        }

        //Add reservations to the database
        foreach (KeyValuePair<Workspace, Employee> reservation in model.Reservations)
        {
            _reservationService.CreateReservation(new Reservation(Guid.NewGuid(), startDate, endDate, reservation.Value,
                reservation.Key));
        }

        return View(model);
    }
}