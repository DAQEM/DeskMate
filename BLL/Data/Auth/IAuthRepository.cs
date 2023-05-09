using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Data.Auth
{
	public interface IAuthRepository
	{
		void RegisterEmployee(UserDTO userDto);
		UserDTO? LoginEmployee(UserDTO userDto);
		bool IsEmailTaken(string email);
	}
}
