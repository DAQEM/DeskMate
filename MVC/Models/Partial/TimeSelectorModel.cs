namespace MVC.Models.Partial;

public class TimeSelectorModel
{
    public string Type { get; set; }
    public DateTime Date { get; set; }

    public int Hours => Date.Hour;

    public int Minutes
    {
        get
        {
            int hour = Date.Minute;
            while (hour % 5 != 0)
            {
                hour++;
            }

            return hour;
        }
    }
}