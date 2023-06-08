namespace BLL.Data.Floor;

public interface IFloorService
{
    List<Entities.Floor> GetAllFloors();
    List<Entities.Floor> GetAllFloorsByLocationId(Guid locationId);
    Entities.Floor? GetFloorWithRoomsAndWorkspacesWithOccupancyById(Guid id, DateTime startDate, DateTime endDate);
}