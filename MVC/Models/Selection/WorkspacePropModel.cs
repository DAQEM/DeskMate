namespace MVC.Models;

public class WorkspacePropModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public static WorkspacePropModel FromWorkspace(BLL.Entities.Workspace workspace)
    {
        return new WorkspacePropModel
        {
            Id = workspace.Id,
            Name = workspace.Name
        };
    }
}