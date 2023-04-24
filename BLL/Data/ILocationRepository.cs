using BLL.DTOs;

namespace BLL.Data;

public interface ILocationRepository
{
    List<LocationDTO> GetAllLocations();
}