namespace MVC.Models;

public class SelectionModel
{
    public int Step { get; set; } = 1;

    public DateTimeSelectionModel DateTimeSelectionModel { get; set; } = new();
    public List<EmployeeModel> EmployeeModels { get; set; } = new();
    public List<WorkspaceModel> WorkspaceModels { get; set; } = new();
}