using BLL.Data.Floor;
using BLL.DTOs;

namespace DAL.Repositories;

public class FloorRepository : IFloorRepository
{
    private readonly DeskMateContext _context;

    public FloorRepository(DeskMateContext context)
    {
        _context = context;
    }

    public List<FloorDTO> GetAllFloors()
    {
        return _context.floor.ToList();
    }

    public List<FloorDTO> GetFloorsByLocationId(Guid locationId)
    {
        return _context.floor.Where(f => f.LocationId == locationId).ToList();
    }
}