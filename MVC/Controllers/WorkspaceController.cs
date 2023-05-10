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
        List<Workspace> workspaces = _workspaceService.GetWorkspacesWithCharacteristicsAndReservations();
        WorkspaceListModel model = new() { Workspaces = workspaces };
        return View(model);
    }
}