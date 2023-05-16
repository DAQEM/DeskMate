using BLL.Entities;

namespace MVC.Models;

public class LocationModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Postal { get; set; }
    public string City { get; set; }
    public string StreetName { get; set; }
    public string HouseNumber { get; set; }

    public static LocationModel FromLocation(Location location)
    {
        return new LocationModel
        {
            Id = location.Id,
            Name = location.Name,
            Country = location.Country,
            Postal = location.Postal,
            City = location.City,
            StreetName = location.StreetName,
            HouseNumber = location.HouseNumber
        };
    }
}