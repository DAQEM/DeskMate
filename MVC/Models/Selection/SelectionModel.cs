namespace MVC.Models;

public class SelectionModel
{
    public bool ReservationIsDone { get; set; } = false;

    public DateTimeSelectionModel DateTimeSelectionModel { get; set; } = new();
    public List<EmployeeModel> EmployeeModels { get; set; } = new();
    public List<WorkspacePropModel> WorkspaceModels { get; set; } = new();
    public List<LocationModel> LocationModels { get; set; } = new();
    public Guid SelectedLocationId { get; set; } = new();
    public List<FloorModel> FloorModels { get; set; } = new();
    public Guid SelectedFloorId { get; set; } = new();
    public Dictionary<string, string> Reservations { get; set; } = new();
}