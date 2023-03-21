namespace MVC.Models;

public class DateSelectorModel
{
    public DateOnly Date { get; set; }
    public TimeOnly TimeFrom { get; set; }
    public TimeOnly TimeTo { get; set; }

    public DateSelectorModel SetMinutesToFives()
    {
        while (TimeFrom.Minute % 5 != 0)
        {
            if (TimeFrom.Minute == 59)
            {
                TimeFrom = TimeFrom.AddHours(1);
                TimeFrom = TimeFrom.AddMinutes(-59);
            }
            else
            {
                TimeFrom = TimeFrom.AddMinutes(1);
            }
        }

        while (TimeTo.Minute % 5 != 0)
        {
            if (TimeTo.Minute == 59)
            {
                TimeTo = TimeTo.AddHours(1);
                TimeTo = TimeTo.AddMinutes(-59);
            }
            else
            {
                TimeTo = TimeTo.AddMinutes(1);
            }
        }

        return this;
    }
}