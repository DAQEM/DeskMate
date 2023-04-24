namespace BLL.Entities;

public class Location
{
    private readonly string _city;
    private readonly string _country;
    private readonly List<Floor> _floors;
    private readonly string _houseNumber;
    private readonly Guid _id;
    private readonly string _name;
    private readonly string _postal;
    private readonly string _streetName;

    public Location(Guid? id = null, string name = "", string country = "", string postal = "",
        string city = "", string streetName = "", string houseNumber = "", List<Floor>? floors = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _country = country;
        _postal = postal;
        _city = city;
        _streetName = streetName;
        _houseNumber = houseNumber;
        _floors = floors ?? new List<Floor>();
    }

    public Guid Id => _id;
    public string Name => _name;
    public string Country => _country;
    public string Postal => _postal;
    public string City => _city;
    public string StreetName => _streetName;
    public string HouseNumber => _houseNumber;
    public List<Floor> Floors => _floors;
}