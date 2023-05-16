namespace BLL.Entities;

public class Room
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly List<Workspace> _workspaces;
    private readonly Floor _floor;
    
    public Room(Guid? id = null, string name = "", List<Workspace>? workspaces = null, Floor? floor = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _workspaces = workspaces ?? new List<Workspace>();
        _floor = floor;
    }
    
    public Guid Id => _id;
    public string Name => _name;
    public List<Workspace> Workspaces => _workspaces;
    public Floor Floor => _floor;
}