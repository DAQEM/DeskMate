using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.Auth;
using BLL.DTOs;

namespace DAL.Repositories
{
	public class AuthRepository : IAuthRepository
	{
		private readonly DeskMateContext _context;

		public AuthRepository(DeskMateContext context)
		{
			_context = context;
		}

		public void RegisterEmployee(UserDTO userDto)
		{
			_context.user.Add(new UserDTO
			{
				Id = Guid.NewGuid(),
				Name = userDto.Name,
				Email = userDto.Email,
				Password = userDto.Password
			});

			_context.SaveChanges();
		}

		public UserDTO? LoginEmployee(UserDTO userDto)
		{
			UserDTO? employee = _context.user.FirstOrDefault(
				u => u.Email == userDto.Email && 
				u.Password == userDto.Password);

			return employee;
		}

		public bool IsEmailTaken(string email)
		{
			return _context.user.Any(u => u.Email == email);
		}
	}
}
