namespace BLL.Data.Floor;

public interface IFloorService
{
    List<Entities.Floor> GetAllFloors();
    List<Entities.Floor> GetFloorsByLocationId(Guid locationId);
}