using BLL.Entities;

namespace MVC.Models.Workspace;

public class WorkspaceDetailModel
{
    public WorkspaceDetailModel(Guid id, string name, string floor, string room, List<Characteristic> characteristics,
        List<BLL.Entities.Reservation> reservations)
    {
        Id = id;
        Name = name;
        Floor = floor;
        Room = room;
        Characteristics = characteristics;
        Reservations = reservations;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Floor { get; set; }

    public string Room { get; set; }


    public List<Characteristic> Characteristics { get; set; }
    public List<BLL.Entities.Reservation> Reservations { get; set; }
}