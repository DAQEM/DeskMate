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

    public List<Entities.Floor> GetFloorsByLocationId(Guid locationId)
    {
        return _floorRepository.GetFloorsByLocationId(locationId).Select(f => f.ToFloor()).ToList();
    }
}