using BLL.Data;
using BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Workspace;

namespace MVC.Controllers;

public class WorkspaceController : BaseController<WorkspaceController>
{
    private readonly IWorkspaceService _workspaceService;

    public WorkspaceController(IWorkspaceService workspaceService)
    {
        _workspaceService = workspaceService;
    }

    [HttpGet]
    [Route("workspaces")]
    public IActionResult Index()
    {
        List<Workspace> workspaces = _workspaceService.GetAllWorkspacesWithCharacteristics();
        WorkspaceListModel model = new() { Workspaces = workspaces };
        return View(model);
    }
}