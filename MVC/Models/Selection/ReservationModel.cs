using BLL.Entities;
namespace MVC.Models;

public class ReservationModel
{
    public Dictionary<BLL.Entities.Workspace, BLL.Entities.Employee> Reservations { get; set; } = new();
}