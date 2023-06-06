namespace MVC.Models.Reservation;

public class ReservationModalModel
{
    public Guid WorkspaceId { get; set; } = new();
    
    public DateTimeSelectionModel DateTimeSelection { get; set; } = new();
}