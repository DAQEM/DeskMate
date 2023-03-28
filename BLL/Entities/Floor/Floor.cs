namespace BLL.Entities;

public class Floor
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly int _floorNumber;
    private readonly Floorplan _floorPlan;
    private readonly List<Room> _rooms;
    
    public Floor(Guid? id = null, string name = "", int floorNumber = 0, 
        Floorplan? floorPlan = null, List<Room>? rooms = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _floorNumber = floorNumber;
        _floorPlan = floorPlan ?? new Floorplan();
        _rooms = rooms ?? new List<Room>();
    }
    
    public Guid Id => _id;
    public string Name => _name;
    public int FloorNumber => _floorNumber;
    public Floorplan FloorPlan => _floorPlan;
    public List<Room> Rooms => _rooms;
}