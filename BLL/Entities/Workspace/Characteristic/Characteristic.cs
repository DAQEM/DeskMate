namespace BLL.Entities;

public class Characteristic
{
    private readonly Guid _id;
    private readonly string _type;
    private readonly int _amount;

	public Characteristic(string type, Guid? id = null, int amount = 0)
    {
        _id = id ?? Guid.Empty;
        _type = type;
        _amount = amount;
    }
    
    public Guid Id => _id;
    public string Type => _type;
    public int Amount => _amount;
}