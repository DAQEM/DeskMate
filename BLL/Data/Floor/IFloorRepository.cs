using BLL.DTOs;

namespace BLL.Data.Floor;

public interface IFloorRepository
{
    List<FloorDTO> GetAllFloors();
    List<FloorDTO> GetAllFloorsByLocationId(Guid locationId);
}