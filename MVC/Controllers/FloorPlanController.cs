using BLL.Data;
using BLL.Data.Floor;
using BLL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.FloorPlan;

namespace MVC.Controllers;

[Route("FloorPlan")]
[Authorize]
public class FloorPlanController : BaseController<FloorPlanController>
{
    private readonly IFloorService _floorService;
    private readonly ILocationService _locationService;

    public FloorPlanController(
        ILocationService locationService,
        IFloorService floorService
    )
    {
        _locationService = locationService;
        _floorService = floorService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        FloorPlanModel model = new();

        List<Floor> allFloors = _floorService.GetAllFloors();

        Floor? firstFloor = allFloors.FirstOrDefault();
        if (firstFloor != null)
        {
            model.SelectedFloorId = firstFloor.Id;
            if (firstFloor.Location != null)
            {
                model.SelectedLocationId = _locationService.GetLocationById(firstFloor.Location.Id)!.Id;
            }
        }

        model.LocationFloorSelection.Locations = _locationService.GetAllLocations();
        model.LocationFloorSelection.Floors =
            allFloors.Where(f => f.Location != null && f.Location.Id == model.SelectedLocationId).ToList();

        model.DateTimeSelection = new DateTimeSelectionModel
        {
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(1)
        };

        model.SelectedFloor = _floorService.GetFloorWithRoomsAndWorkspacesWithOccupancyById(model.SelectedFloorId,
            model.DateTimeSelection.StartTime, model.DateTimeSelection.EndTime)!;

        return View(model);
    }

    [HttpPost("")]
    public IActionResult Index(FloorPlanModel model)
    {
        model.LocationFloorSelection.Locations = _locationService.GetAllLocations();
        model.LocationFloorSelection.Floors =
            _floorService.GetAllFloorsByLocationId(
                model.SelectedLocationId
            );

        if (model.LocationFloorSelection.Floors.Any(f => f.Id == model.SelectedFloorId) == false)
        {
            model.SelectedFloorId = model.LocationFloorSelection.Floors.FirstOrDefault()?.Id ?? Guid.Empty;
        }

        model.SelectedFloor = _floorService.GetFloorWithRoomsAndWorkspacesWithOccupancyById(
            model.SelectedFloorId,
            model.DateTimeSelection.GetStartDateTimeWithDate(),
            model.DateTimeSelection.GetEndDateTimeWithDate())!;

        return View("Index", model);
    }
}