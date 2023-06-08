using BLL.Entities;

namespace MVC.Models.Workspace;

public class WorkspacesFilterModel
{
    public bool IsAvailable { get; set; } = false;
    public Dictionary<string, bool> Characteristics { get; set; } = new();

    public Guid SelectedLocationId { get; set; } = new();
    public Guid SelectedFloorId { get; set; } = new();
    public Guid SelectedRoomId { get; set; } = new();

    public List<Location> Locations { get; set; } = new();
    public List<Floor> Floors { get; set; } = new();
    public List<Room> Rooms { get; set; } = new();
}