using BLL.DTOs;

namespace BLL.Entities;

public class Characteristic
{
    private readonly int _amount;
    private readonly Guid _id;

    private readonly string _type;
    private readonly int _amount;

	public Characteristic(string type, Guid? id = null, int amount = 0)

    private readonly CharacteristicType _type;



    {
        _id = id ?? Guid.Empty;
        _type = type;
        _amount = amount;
    }

    public Guid Id => _id;
    public string Type => _type;
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