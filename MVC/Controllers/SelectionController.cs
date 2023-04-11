using BLL.Data;
using BLL.Data.Floor;
using BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

[Route("Selection")]
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
    [Route("")]
    public IActionResult Index()
    {
        //TODO: Get the employee from the session
        List<EmployeeModel> employeeModels =
            new() { new EmployeeModel(new Employee(Guid.NewGuid(), "Me")) };

        List<LocationModel> locationModels =
            _locationService.GetAllLocations().Select(LocationModel.FromLocation).ToList();

        List<FloorModel> floorModels =
            _floorService.GetFloorsByLocationId(locationModels[0].Id).Select(FloorModel.FromFloor).ToList();

        List<WorkspacePropModel> workspaceModels =
            _workspaceService.GetWorkspacesByFloorId(floorModels[0].Id).Select(WorkspacePropModel.FromWorkspace)
                .ToList();

        SelectionModel model = new()
        {
            EmployeeModels = employeeModels,
            LocationModels = locationModels,
            FloorModels = floorModels,
            WorkspaceModels = workspaceModels
        };

        return View(model);
    }

    [HttpPost]
    [Route("")]
    public IActionResult Selection(SelectionModel model)
    {
        return View("Index", model);
    }
}