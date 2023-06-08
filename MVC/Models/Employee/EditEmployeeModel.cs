using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Employee;

public class EditEmployeeModel
{
    [Required(ErrorMessage = "Requires an username")]
    [StringLength(24)]
    [RegularExpression("^[a-zA-Z0-9]{1,24}$", ErrorMessage = "Only letters and numbers allowed")]
    public string? Name { get; set; }

    [DataType(DataType.Password)] public string? Password { get; set; }

    [Compare("Password", ErrorMessage = "Passwords must match.")]
    [DataType(DataType.Password)]
    public string? ConfirmPassword { get; set; }
}