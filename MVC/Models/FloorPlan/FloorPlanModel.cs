using BLL.Entities;

namespace MVC.Models.FloorPlan;

public class FloorPlanModel
{
    public Guid SelectedLocationId { get; set; } = new();
    public Guid SelectedFloorId { get; set; } = new();

    public LocationFloorSelectionModel LocationFloorSelection { get; set; } = new();
    public DateTimeSelectionModel DateTimeSelection { get; set; } = new();

    //For Floor plan
    public Floor SelectedFloor { get; set; } = new();
}