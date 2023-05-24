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
        List<Workspace> workspaces = _workspaceService.GetWorkspacesWithCharacteristicsAndReservationsAndRoomAndFloor();
        WorkspaceListModel model = new() { Workspaces = workspaces };
        return View(model);
    }

    [HttpGet]
    [Route("Detail")]
    public IActionResult Detail(Guid id)
    {
        Workspace workspace = _workspaceService.GetWorkspaceWithCharateristicsAndReservationsAndRoomAndFloorByWorkplaceId(id);
        List <Reservation> reservations = _workspaceService.GetReservationsAndUserFromCurrentDate(workspace);
        WorkspaceDetailModel model = new(workspace.Name, workspace.Room.Floor.Name, workspace.Room.Name, workspace.Characteristics, reservations);
        return View(model);
    }
}