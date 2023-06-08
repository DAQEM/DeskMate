namespace MVC.Models.Workspace;

public class WorkspacesOverviewModel
{
    public WorkspaceListModel Workspaces { get; set; } = new();
    public WorkspacesFilterModel Filter { get; set; } = new();
}