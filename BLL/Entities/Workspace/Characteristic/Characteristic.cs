namespace BLL.Entities;

public class Characteristic
{
    private readonly Guid _id;
    private readonly CharacteristicType _type;
    private readonly int _amount;
    
    public Characteristic(Guid? id = null, CharacteristicType type = CharacteristicType.Empty, int amount = 0)
    {
        _id = id ?? Guid.Empty;
        _type = type;
        _amount = amount;
    }
    
    public Guid Id => _id;
    public CharacteristicType Type => _type;
    public int Amount => _amount;
}