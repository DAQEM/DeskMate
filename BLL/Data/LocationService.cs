using BLL.Entities;

namespace BLL.Data;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;

    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public List<Location> GetAllLocations()
    {
        return _locationRepository.GetAllLocations().Select(l => l.ToLocation()).ToList();
    }
}