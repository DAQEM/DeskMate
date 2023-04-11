using BLL.Data;
using BLL.Data.Floor;
using BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class SelectionController : BaseController<SelectionController>
{
    private readonly IFloorService _floorService;
    private readonly ILocationService _locationService;
    private readonly IWorkspaceService _workspaceService;

    public SelectionController(ILocationService locationService, IFloorService floorService,
        IWorkspaceService workspaceService)
    {
        _locationService = locationService;
        _floorService = floorService;
        _workspaceService = workspaceService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new SelectionModel());
    }

    [HttpPost]
    public IActionResult Selection(SelectionModel model)
    {
        Console.WriteLine(model.Step);
        return model.Step switch
        {
            2 => DateTimeSelection(model),
            3 => EmployeeSelection(model),
            4 => LocationSelection(model),
            5 => FloorSelection(model),
            6 => WorkspaceSelection(model),
            _ => Index()
        };
    }

    [HttpPost]
    public IActionResult DateTimeSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " +
                          model.DateTimeSelectionModel.Date.ToShortDateString() + " " +
                          model.DateTimeSelectionModel.StartTime.ToShortTimeString() + " " +
                          model.DateTimeSelectionModel.EndTime.ToShortTimeString());
        //TODO: Get employees from database
        model.EmployeeModels = new List<EmployeeModel>
            { new(new Employee(Guid.NewGuid(), "Viewer name")) };
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult EmployeeSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " + model.EmployeeModels.Count);
        model.LocationModels = _locationService.GetAllLocations().Select(LocationModel.FromLocation).ToList();
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult LocationSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " + model.LocationModels.Count);
        model.LocationModels = _locationService.GetAllLocations().Select(LocationModel.FromLocation).ToList();
        model.FloorModels = _floorService.GetFloorsByLocationId(model.SelectedLocationId)
            .Select(FloorModel.FromFloor).ToList();
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult FloorSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " + model.FloorModels.Count);
        model.LocationModels = _locationService.GetAllLocations().Select(LocationModel.FromLocation).ToList();
        model.FloorModels = _floorService.GetFloorsByLocationId(model.SelectedLocationId)
            .Select(FloorModel.FromFloor).ToList();
        model.WorkspaceModels = _workspaceService.GetWorkspacesByFloorId(model.SelectedFloorId)
            .Select(WorkspacePropModel.FromWorkspace).ToList();
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult WorkspaceSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " + model.WorkspaceModels.Count);
        foreach (KeyValuePair<string, string> keyValuePair in model.Reservations)
        {
            Console.WriteLine("Reservation: " + keyValuePair.Key + " " + keyValuePair.Value);
        }

        model.LocationModels = _locationService.GetAllLocations().Select(LocationModel.FromLocation).ToList();
        model.FloorModels = _floorService.GetFloorsByLocationId(model.SelectedLocationId)
            .Select(FloorModel.FromFloor).ToList();
        model.WorkspaceModels = _workspaceService.GetWorkspacesByFloorId(model.SelectedFloorId)
            .Select(WorkspacePropModel.FromWorkspace).ToList();
        return View("Index", model);
    }
}