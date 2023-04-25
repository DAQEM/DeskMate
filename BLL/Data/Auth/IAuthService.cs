using BLL.DTOs;

namespace BLL.Data.Auth
{
	public interface IAuthService
	{
		bool RegisterEmployeeIfNotTaken(UserDTO userDto);
		Entities.Employee? LoginEmployee(Employee employee);
	}
}
