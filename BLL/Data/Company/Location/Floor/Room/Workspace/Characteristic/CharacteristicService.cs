using BLL.Entities;

namespace BLL.Data;

public class CharacteristicService : ICharacteristicService
{
    private readonly ICharacteristicRepository _characteristicRepository;
    
    public CharacteristicService(ICharacteristicRepository characteristicRepository)
    {
        _characteristicRepository = characteristicRepository;
    }
    
    public List<Characteristic> GetCharacteristicsForWorkspace(Workspace workspace)
    {
        return _characteristicRepository.GetCharacteristicsForWorkspace(workspace);
    }
}