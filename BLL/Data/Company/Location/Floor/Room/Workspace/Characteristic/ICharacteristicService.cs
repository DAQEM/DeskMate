using BLL.Entities;

namespace BLL.Data;

public interface ICharacteristicService
{
    List<Characteristic> GetCharacteristicsForWorkspace(Workspace workspace);
}