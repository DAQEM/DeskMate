using BLL.Entities;

namespace MVC.Models;

public class WorkspacePropModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Occupied { get; set; }
    public List<Characteristic> Characteristics { get; set; }

    public static WorkspacePropModel FromWorkspace(BLL.Entities.Workspace workspace)
    {
        return new WorkspacePropModel
        {
            Id = workspace.Id,
            Name = workspace.Name,
            Occupied = workspace.Occupied,
            Characteristics = workspace.Characteristics
        };
    }

    public static WorkspacePropModel FromWorkspaceWithOccupied(BLL.Entities.Workspace workspace, DateTime startDate,
        DateTime endDate)
    {
        return new WorkspacePropModel
        {
            Id = workspace.Id,
            Name = workspace.Name,
            Occupied = workspace.IsOccupied(startDate, endDate),
            Characteristics = workspace.Characteristics
        };
    }
}