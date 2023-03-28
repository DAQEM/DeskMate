namespace BLL.Entities;

public class Employee
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly string _email;
    private readonly string _hashedPassword;
    private readonly List<Reservation> _reservations;
    
    public Employee(Guid? id = null, string name = "", string email = "", string hashedPassword = "", 
        List<Reservation>? reservations = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _email = email;
        _hashedPassword = hashedPassword;
        _reservations = reservations ?? new List<Reservation>();
    }
    
    public Guid Id => _id;
    public string Name => _name;
    public string Email => _email;
    public List<Reservation> Reservations => _reservations;
    
    public bool HasReservationForDate(DateTime date)
    {
        return _reservations.Any(r => r.IsActiveOn(date));
    }
}