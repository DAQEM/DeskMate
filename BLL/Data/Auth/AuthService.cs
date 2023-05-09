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

		public bool RegisterEmployeeIfNotTaken(Entities.Employee employee)
		{
			if (IsEmailTaken(employee.Email)) return true;

            employee.HashPassword();

			_authRepository.RegisterEmployee(employee.ToUserDTO());

			return false;
		}

		public Entities.Employee? LoginEmployee(Entities.Employee employee)
		{
            employee.HashPassword();

			return _authRepository.LoginEmployee(employee.ToUserDTO())?.ToEmployee();
		}

		public bool IsEmailTaken(string email)
		{
			return _authRepository.IsEmailTaken(email);
		}
    }
}
