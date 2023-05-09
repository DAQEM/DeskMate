using BLL.DTOs;

namespace BLL.Data.Auth
{
	public interface IAuthService
	{
		bool RegisterEmployeeIfNotTaken(Entities.Employee userDto);
		Entities.Employee? LoginEmployee(Entities.Employee employee);
	}
}
