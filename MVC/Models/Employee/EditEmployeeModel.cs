using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Employee
{
	public class EditEmployeeModel
	{
		[StringLength(26, MinimumLength = 3, ErrorMessage = "Must be between 3 and 26 characters.")]
		public string? Name { get; set; }

		[DataType(DataType.Password)]
		public string? Password { get; set; }

		[Compare("Password", ErrorMessage = "Passwords must match.")]
		[DataType(DataType.Password)]
		public string? ConfirmPassword { get; set; }
	}
}