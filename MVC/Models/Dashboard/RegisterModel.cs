using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Dashboard;

public class RegisterModel
{
    [Required(ErrorMessage = "Requires an username")]
    [StringLength(24)]
    [RegularExpression("^[a-zA-Z0-9]{1,24}$", ErrorMessage = "Only letters and numbers allowed")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Requires an e-mail address")]
    [EmailAddress(ErrorMessage = "Invalid e-mail address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Requires a password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Requires password validation")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;
}