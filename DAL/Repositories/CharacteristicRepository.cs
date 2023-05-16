using BLL.Data;
using BLL.Entities;

namespace DAL.Repositories;

public class CharacteristicRepository : ICharacteristicRepository
{
    private readonly DeskMateContext _context;

    public CharacteristicRepository(DeskMateContext context)
    {
        _context = context;
    }

    public List<Characteristic> GetCharacteristicsForWorkspace(Workspace workspace)
    {
        //Todo: Implement this method
        return new List<Characteristic>();
    }
}