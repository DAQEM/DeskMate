using System.Security.Claims;
using BLL.Data;
using BLL.Data.Employee;
using BLL.Data.Employee.Reservation;
using BLL.Data.Floor;
using BLL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Reservation;

namespace MVC.Controllers;

[Authorize]
[Route("Reservation")]
public class ReservationController : BaseController<ReservationController>
{
    private readonly IEmployeeService _employeeService;
    private readonly IFloorService _floorService;
    private readonly ILocationService _locationService;
    private readonly IReservationService _reservationService;
    private readonly IWorkspaceService _workspaceService;

    public ReservationController(IReservationService reservationService, IFloorService floorService,
        ILocationService locationService, IEmployeeService employeeService, IWorkspaceService workspaceService)
    {
        _reservationService = reservationService;
        _floorService = floorService;
        _locationService = locationService;
        _employeeService = employeeService;
        _workspaceService = workspaceService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("delete/{guid}")]
    public IActionResult Delete(Guid guid)
    {
        _reservationService.DeleteReservation(guid);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("edit/{guid}")]
    public IActionResult Edit(Guid guid)
    {
        EditReservationModel model = new();
        Reservation? reservation =
            _reservationService.GetReservationWithEmployeeWorkspaceRoomFloorAndLocationById(guid);

        if (reservation != null)
        {
            model.DateTimeSelectionModel = new DateTimeSelectionModel
            {
                Date = reservation.StartDate,
                StartTime = reservation.StartDate,
                EndTime = reservation.EndDate
            };
        }

        return View(model);
    }

    [HttpPost]
    [Route("edit/{guid}")]
    public IActionResult Edit(Guid guid, EditReservationModel model)
    {
        if (ModelState.IsValid)
        {
            Reservation? reservation =
                _reservationService.GetReservationWithEmployeeWorkspaceRoomFloorAndLocationById(guid);

            if (reservation != null)
            {
                _reservationService.UpdateReservation(new Reservation(
                    reservation.Id,
                    model.DateTimeSelectionModel.Date.Add(model.DateTimeSelectionModel.StartTime.TimeOfDay),
                    model.DateTimeSelectionModel.Date.Add(model.DateTimeSelectionModel.EndTime.TimeOfDay),
                    reservation.Employee,
                    reservation.Workspace
                ));
                return RedirectToAction("Index");
            }
        }

        return View(model);
    }

    [HttpGet]
    [Route("/api/filtered/reservation")]
    public IActionResult GetFilteredReservations(string dateFrom, string dateTo)
    {
        List<Reservation> reservations =
            _reservationService.GetFilteredReservations(DateTime.Parse(dateFrom), DateTime.Parse(dateTo));
        return new JsonResult(new { reservations });
    }

    [HttpGet]
    [Route("/api/filtered/reservation/{employeeId}")]
    public IActionResult GetFilteredReservationsByEmployeeId(string employeeId, string dateFrom, string dateTo)
    {
        if (!Guid.TryParse(employeeId, out Guid employeeGuid))
        {
            return new JsonResult(new { error = "Invalid employee id" });
        }

        List<Reservation> reservations =
            _reservationService.GetFilteredReservationsByEmployeeId(employeeGuid, DateTime.Parse(dateFrom),
                DateTime.Parse(dateTo)).OrderBy(reservation => reservation.StartDate).ToList();
        return new JsonResult(new { reservations });
    }

    [HttpPost("Modal")]
    public IActionResult Modal(ReservationModalModel model)
    {
        Console.WriteLine(model.Date);

        List<string> errors = new();

        if (model.Date == null)
        {
            errors.Add("Date is required");
        }

        if (model.StartTime == null)
        {
            errors.Add("Start time is required");
        }

        if (model.EndTime == null)
        {
            errors.Add("End time is required");
        }

        if (model.Date != null && model.StartTime != null && model.EndTime != null)
        {
            if (model.StartTime > model.EndTime)
            {
                errors.Add("Start time cannot be after end time");
            }

            if (model.StartTime == model.EndTime)
            {
                errors.Add("Start time cannot be the same as end time");
            }

            if (model.Date < DateTime.Now.Date)
            {
                errors.Add("Date cannot be in the past");
            }

            List<Reservation> reservations =
                _reservationService.GetRunningReservationsForWorkspace(
                        model.WorkspaceId,
                        model.GetStartDateTimeWithDate(),
                        model.GetEndDateTimeWithDate())
                    .ToList();

            if (reservations.Any())
                foreach (Reservation reservation in reservations)
                {
                    errors.Add("Existing reservation: " + reservation.StartDate.TimeOfDay + " - " +
                               reservation.EndDate.TimeOfDay);
                }
        }

        if (!errors.Any())
        {
            Reservation reservation = new(
                null,
                model.GetStartDateTimeWithDate(),
                model.GetEndDateTimeWithDate(),
                _employeeService.GetEmployeeById(new Guid(User.FindFirst(ClaimTypes.NameIdentifier)!.Value)),
                _workspaceService.GetWorkspaceWithCharateristicsAndReservationsAndRoomAndFloorByWorkplaceId(
                    model.WorkspaceId));

            _reservationService.CreateReservation(reservation);
            return new JsonResult(new { success = true });
        }


        return new JsonResult(new
            { success = false, errors });
    }
}