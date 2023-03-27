namespace MVC.Models;

public class DateTimeSelectionModel
{
    public DateTime Date { get; set; } = DateTime.Now;
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime EndTime { get; set; } = DateTime.Now.AddHours(1);
}