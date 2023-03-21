namespace BLL.Entities;

public class Company
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly List<Location> _locations;

    public Company(Guid? id = null, string name = "", List<Location>? locations = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _locations = locations ?? new List<Location>();
    }
    
    public Guid Id => _id;
    public string Name => _name;
    public List<Location> Locations => _locations;
}