using System.Security.Cryptography;
using System.Text;
using BLL.DTOs;

namespace BLL.Entities;

public class Employee
{
    private readonly string _email;
    private readonly Guid _id;
    private readonly string _name;
    private readonly List<Reservation> _reservations;
    private readonly Role _role;

    public Employee(Guid? id = null, string name = "", string email = "", string hashedPassword = "",
        List<Reservation>? reservations = null, Role? role = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _email = email;
        HashedPassword = hashedPassword;
        _reservations = reservations ?? new List<Reservation>();
        _role = role ?? new Role();
    }

    public Guid Id => _id;
    public string Name => _name;
    public string Email => _email;
    public List<Reservation> Reservations => _reservations;
    public string HashedPassword { get; private set; }
    public Role Role => _role;

    public bool HasReservationForDate(DateTime date)
    {
        return _reservations.Any(r => r.IsActiveOn(date));
    }

    public UserDTO ToUserDTO()
    {
        return new UserDTO
        {
            Id = _id,
            Name = _name,
            Email = _email,
            Password = HashedPassword,
            reservationDTOs = _reservations.Select(r => r.ToReservationDTO()).ToList()
        };
    }

    public void HashPassword()
    {
        MD5 md5 = MD5.Create();

        byte[] inputBytes = Encoding.ASCII.GetBytes(HashedPassword);
        byte[] hash = md5.ComputeHash(inputBytes);

        StringBuilder sb = new();

        foreach (byte b in hash)
        {
            sb.Append(b.ToString("X2"));
        }

        HashedPassword = sb.ToString();
    }
}