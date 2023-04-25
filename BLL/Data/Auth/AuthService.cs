using BLL.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Data.Auth
{
	public class AuthService : IAuthService
	{
		private readonly IAuthRepository _authRepository;

		public AuthService(IAuthRepository authRepository)
		{
			_authRepository = authRepository;
		}

		public bool RegisterEmployeeIfNotTaken(UserDTO userDto)
		{
			if (IsEmailTaken(userDto.Email)) return true;

			//userDto.Password = HashPassword(userDto.Password);
			_authRepository.RegisterEmployee(userDto);

			return false;
		}

		public Entities.Employee? LoginEmployee(Entities.Employee employee)
		{
            employee.HashPassword();

			return _authRepository.LoginEmployee(employee)?.ToEmployee();
		}

		public bool IsEmailTaken(string email)
		{
			return _authRepository.IsEmailTaken(email);
		}
    }
}
