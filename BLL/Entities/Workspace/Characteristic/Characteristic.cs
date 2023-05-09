using BLL.DTOs;

namespace BLL.Entities;

public class Characteristic
{
    private readonly int _amount;
    private readonly Guid _id;
    private readonly CharacteristicType _type;

    public Characteristic(Guid? id = null, CharacteristicType type = CharacteristicType.Empty, int amount = 0)
    {
        _id = id ?? Guid.Empty;
        _type = type;
        _amount = amount;
    }

    public Guid Id => _id;
    public CharacteristicType Type => _type;
    public int Amount => _amount;

    public CharacteristicDTO ToCharacteristicDTO()
    {
        return new CharacteristicDTO
        {
            Id = _id,
            Type = (int)_type
        };
    }
}