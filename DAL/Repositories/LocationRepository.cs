using BLL.Data;
using BLL.DTOs;

namespace DAL.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly DeskMateContext _context;

    public LocationRepository(DeskMateContext context)
    {
        _context = context;
    }

    public List<LocationDTO> GetAllLocations()
    {
        return _context.location.ToList();
    }

    public LocationDTO? GetLocationById(Guid locationId)
    {
        return _context.location.FirstOrDefault(l => l.Id == locationId);
    }
}