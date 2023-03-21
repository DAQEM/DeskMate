namespace BLL.Entities.Company.Location.Floor.Room.Workspace.Characteristic;

public class Characteristic
{
    private readonly Guid _id;
    private readonly string _name;
    
    public Characteristic(Guid? id = null, string name = "")
    {
        _id = id ?? Guid.Empty;
        _name = name;
    }
    
    public Guid Id => _id;
    public string Name => _name;
}