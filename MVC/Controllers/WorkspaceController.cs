using BLL.Data;
using BLL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Workspace;

namespace MVC.Controllers;

[Authorize]
[Route("workspace")]
public class WorkspaceController : BaseController<WorkspaceController>
{
    private readonly IWorkspaceService _workspaceService;

    public WorkspaceController(IWorkspaceService workspaceService)
    {
        _workspaceService = workspaceService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        List<Workspace> workspaces =
            _workspaceService.GetWorkspacesWithCharacteristicsAndReservationsAndRoomAndFloorAndLocation();

        List<Location> locations = workspaces
            .Where(w => w.Room.Floor.Location != null)
            .Select(w => w.Room.Floor.Location!)
            .GroupBy(l => l.Name)
            .Select(g => g.First())
            .ToList();

        List<Characteristic> characteristics = workspaces
            .SelectMany(w => w.Characteristics)
            .GroupBy(c => c.Type)
            .Select(g => g.First())
            .ToList();

        WorkspacesOverviewModel model = new()
        {
            Workspaces = new WorkspaceListModel
            {
                Workspaces = workspaces
            },
            Filter = new WorkspacesFilterModel
            {
                Locations = locations,
                Characteristics = characteristics.ToDictionary(c => c.Type, _ => false)
            }
        };
        return View(model);
    }

    [HttpPost]
    [Route("")]
    public IActionResult Filter(WorkspacesFilterModel model)
    {
        List<Workspace> workspaces =
            _workspaceService.GetWorkspacesWithCharacteristicsAndReservationsAndRoomAndFloorAndLocation();

        List<Location> locations = workspaces
            .Where(w => w.Room.Floor.Location != null)
            .Select(w => w.Room.Floor.Location!)
            .GroupBy(l => l.Name)
            .Select(g => g.First())
            .ToList();

        List<Floor> floors = new();

        if (model.SelectedLocationId != Guid.Empty)
        {
            floors = workspaces
                .Where(w => w.Room.Floor.Location!.Id == model.SelectedLocationId)
                .Select(w => w.Room.Floor)
                .GroupBy(f => f.Name)
                .Select(g => g.First())
                .ToList();
        }

        List<Room> rooms = new();

        if (model.SelectedFloorId != Guid.Empty)
        {
            rooms = workspaces
                .Where(w => w.Room.Floor.Id == model.SelectedFloorId)
                .Select(w => w.Room)
                .GroupBy(r => r.Name)
                .Select(g => g.First())
                .ToList();
        }

        List<Characteristic> characteristics = workspaces
            .SelectMany(w => w.Characteristics)
            .GroupBy(c => c.Type)
            .Select(g => g.First())
            .ToList();

        if (model.IsAvailable)
        {
            workspaces = workspaces.Where(w => !w.Occupied).ToList();
        }

        if (model.SelectedLocationId != Guid.Empty)
        {
            workspaces = workspaces.Where(w => w.Room.Floor.Location!.Id == model.SelectedLocationId).ToList();
        }

        if (model.SelectedFloorId != Guid.Empty)
        {
            workspaces = workspaces.Where(w => w.Room.Floor.Id == model.SelectedFloorId).ToList();
        }

        if (model.SelectedRoomId != Guid.Empty)
        {
            workspaces = workspaces.Where(w => w.Room.Id == model.SelectedRoomId).ToList();
        }

        if (model.Characteristics.Any(c => c.Value))
        {
            workspaces = model.Characteristics
                .Where(c => c.Value)
                .Aggregate(workspaces, (current, keyValuePair) => current
                    .Where(w => w.Characteristics
                        .Any(c => c.Type == keyValuePair.Key))
                    .ToList());
        }


        WorkspacesOverviewModel overviewModel = new()
        {
            Workspaces = new WorkspaceListModel
            {
                Workspaces = workspaces
            },
            Filter = new WorkspacesFilterModel
            {
                Locations = locations,
                Floors = floors,
                Rooms = rooms,
                SelectedLocationId = model.SelectedLocationId,
                SelectedFloorId = model.SelectedFloorId,
                SelectedRoomId = model.SelectedRoomId,
                Characteristics = characteristics.ToDictionary(c => c.Type, _ => false)
            }
        };
        return View("Index", overviewModel);
    }

    [HttpGet]
    [Route("Detail")]
    public IActionResult Detail(Guid id)
    {
        Workspace workspace =
            _workspaceService.GetWorkspaceWithCharateristicsAndReservationsAndRoomAndFloorByWorkplaceId(id);
        List<Reservation> reservations = _workspaceService.GetReservationsAndUserFromCurrentDate(workspace);
        WorkspaceDetailModel model = new(workspace.Id, workspace.Name, workspace.Room.Floor.Name, workspace.Room.Name,
            workspace.Characteristics, reservations);
        return View(model);
    }
}