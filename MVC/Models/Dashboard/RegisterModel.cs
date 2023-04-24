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
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Requires password validation")]
    public string ConfirmPassword { get; set; } = string.Empty;
}