using BLL.Data;
using BLL.Entities;

namespace DAL.Repositories;

public class CharacteristicRepository : ICharacteristicRepository
{
    public List<Characteristic> GetCharacteristicsForWorkspace(Workspace workspace)
    {
        return new List<Characteristic>()
        {
            //TODO: Get characteristics from database
            //These are just some examples
            new(type: CharacteristicType.Keyboard, amount: 1),
            new(type: CharacteristicType.Mouse, amount: 1),
            new(type: CharacteristicType.Monitor, amount: 2),
            new(type: CharacteristicType.WallOutlet, amount: 3),
        };
    }
}