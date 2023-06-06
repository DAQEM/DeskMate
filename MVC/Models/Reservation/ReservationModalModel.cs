namespace MVC.Models.Reservation;

public class ReservationModalModel
{
    public Guid WorkspaceId { get; set; } = new();
    public string WorkspaceName { get; set; } = string.Empty;
    public string FloorName { get; set; } = string.Empty;

    public DateTime? Date { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public DateTime GetStartDateTimeWithDate()
    {
        return new DateTime(Date!.Value.Year, Date!.Value.Month, Date!.Value.Day, StartTime!.Value.Hour,
            StartTime!.Value.Minute, StartTime!.Value.Second);
    }

    public DateTime GetEndDateTimeWithDate()
    {
        return new DateTime(Date!.Value.Year, Date!.Value.Month, Date!.Value.Day, EndTime!.Value.Hour,
            EndTime!.Value.Minute, EndTime!.Value.Second);
    }
}