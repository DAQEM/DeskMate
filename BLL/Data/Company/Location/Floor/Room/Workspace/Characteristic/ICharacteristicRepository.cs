using BLL.Entities;

namespace BLL.Data;

public interface ICharacteristicRepository
{
    List<Characteristic> GetCharacteristicsForWorkspace(Workspace workspace);
}