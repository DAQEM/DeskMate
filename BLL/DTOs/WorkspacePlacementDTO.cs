using BLL.Entities;

namespace BLL.DTOs;

public class WorkspacePlacementDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid WorkspaceId { get; set; }
    public WorkspaceDTO workspaceDTO { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Rotation { get; set; }

    public WorkspacePlacement? ToWorkspacePlacement()
    {
        return new WorkspacePlacement(
            Id,
            PositionX,
            PositionY,
            Width,
            Height,
            Rotation);
    }
}