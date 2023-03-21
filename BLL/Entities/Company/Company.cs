namespace BLL.Entities.Company;

public class Company
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly List<Location.Location> _locations;

    public Company(Guid? id = null, string name = "", List<Location.Location>? locations = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _locations = locations ?? new List<Location.Location>();
    }
    
    public Guid Id => _id;
    public string Name => _name;
    public List<Location.Location> Locations => _locations;
}