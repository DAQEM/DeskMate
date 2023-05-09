namespace BLL.Entities;

public class Workspace
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly List<Characteristic> _characteristics;
    private readonly List<Reservation> _reservations;
    
    public Workspace(Guid? id = null, string name = "", 
        List<Characteristic>? characteristics = null, List<Reservation>? reservations = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _characteristics = characteristics ?? new List<Characteristic>();
        _reservations = reservations ?? new List<Reservation>();
    }
    
    public Guid Id => _id;
    public string Name => _name;
    public List<Characteristic> Characteristics => _characteristics;
    public List<Reservation> Reservations => _reservations;
    
    public void SetCharacteristics(List<Characteristic> characteristics)
    {
        _characteristics.Clear();
        _characteristics.AddRange(characteristics);
    }
}