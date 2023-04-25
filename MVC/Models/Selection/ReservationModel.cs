using BLL.Entities;

namespace MVC.Models;

public class ReservationModel
{
    public List<string> DataTransferList { get; set; } = new();

    public Dictionary<BLL.Entities.Workspace, Employee> Reservations { get; set; } = new();
}