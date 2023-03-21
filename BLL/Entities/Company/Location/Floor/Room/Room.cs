namespace BLL.Entities.Company.Location.Floor.Room;

public class Room
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly List<Workspace.Workspace> _workspaces;
    
    public Room(Guid? id = null, string name = "", List<Workspace.Workspace>? workspaces = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _workspaces = workspaces ?? new List<Workspace.Workspace>();
    }
    
    public Guid Id => _id;
    public string Name => _name;
    public List<Workspace.Workspace> Workspaces => _workspaces;
}