using BLL.Entities;

namespace MVC.Models;

public class LocationFloorSelectionModel
{
    public List<Location> Locations { get; set; } = new();
    public List<Floor> Floors { get; set; } = new();
}