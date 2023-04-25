using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Auth;

public class LoginModel
{
    [Required]
    [DataType(DataType.EmailAddress, ErrorMessage = "Requires a valid e-mail address.")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password, ErrorMessage = "Requires a valid password.")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Remember me")] public bool RememberMe { get; set; }
}