namespace BLL.Entities.Company.Location;

public class Location
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly string _country;
    private readonly string _postal;
    private readonly string _city;
    private readonly string _street;
    private readonly string _streetNumber;
    private readonly List<Floor.Floor> _floors;
    
    public Location(Guid? id = null, string name = "", string country = "", string postal = "", 
        string city = "", string street = "", string streetNumber = "", List<Floor.Floor>? floors = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _country = country;
        _postal = postal;
        _city = city;
        _street = street;
        _streetNumber = streetNumber;
        _floors = floors ?? new List<Floor.Floor>();
    }
    
    public Guid Id => _id;
    public string Name => _name;
    public string Country => _country;
    public string Postal => _postal;
    public string City => _city;
    public string Street => _street;
    public string StreetNumber => _streetNumber;
    public List<Floor.Floor> Floors => _floors;
}