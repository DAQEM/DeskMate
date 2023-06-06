using System.ComponentModel.DataAnnotations;

namespace MVC.Models;

public class DateTimeSelectionModel : IValidatableObject
{
    public DateTime Date { get; set; } = DateTime.Now;
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime EndTime { get; set; } = DateTime.Now.AddHours(1);

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndTime < StartTime)
        {
            yield return new ValidationResult(
                "End time must be greater than the start time.",
                new[] { "EndTime" }
            );
        }

        if (Date < DateTime.Now.Date)
        {
            yield return new ValidationResult(
                "Date must be greater than or equal to today.",
                new[] { "Date" }
            );
        }
    }

    public DateTime GetStartDateTimeWithDate()
    {
        return new DateTime(Date.Year, Date.Month, Date.Day, StartTime.Hour, StartTime.Minute, StartTime.Second);
    }

    public DateTime GetEndDateTimeWithDate()
    {
        return new DateTime(Date.Year, Date.Month, Date.Day, EndTime.Hour, EndTime.Minute, EndTime.Second);
    }
}