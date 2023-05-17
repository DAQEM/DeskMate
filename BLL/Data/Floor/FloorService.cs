using BLL.Entities;

namespace BLL.Data.Floor;

public class FloorService : IFloorService
{
    private readonly IFloorRepository _floorRepository;

    public FloorService(IFloorRepository floorRepository)
    {
        _floorRepository = floorRepository;
    }

    public List<Entities.Floor> GetAllFloors()
    {
        return _floorRepository.GetAllFloors().Select(f => f.ToFloor()).ToList();
    }

    public List<Entities.Floor> GetAllFloorsByLocationId(Guid locationId)
    {
        return _floorRepository.GetAllFloorsByLocationId(locationId).Select(f => f.ToFloor()).ToList();
    }

    public Entities.Floor? GetFloorWithRoomsAndWorkspacesWithOccupancyById(Guid id, DateTime startDate,
        DateTime endDate)
    {
        Entities.Floor? floor = _floorRepository.GetFloorWithRoomsAndWorkspacesWithOccupancyById(id)
            ?.ToFloorWithRoomsWorkspacesAndReservationsAndPlacement();

        if (floor != null)
        {
            foreach (Workspace workspace in floor.Rooms.SelectMany(r => r.Workspaces))
            {
                if (workspace.IsOccupied(startDate, endDate))
                {
                    workspace.Occupied = true;
                }
            }
        }

        return floor;
    }
}