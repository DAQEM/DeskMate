using System.ComponentModel;
using BLL.Entities;

namespace MVC.Models.Workspace
{
    public class WorkspaceDetailModel
    {
        public string Name { get; set; }

        public string Floor { get; set; }

        public string Room { get; set; }


        public List<Characteristic> Characteristics { get; set; }
        public List<BLL.Entities.Reservation> Reservations { get; set; }

        public WorkspaceDetailModel(string name, string floor, string room, List<Characteristic> characteristics, List<BLL.Entities.Reservation> reservations)
        {
            Name = name;
            Floor = floor;
            Room = room;
            Characteristics = characteristics;
            Reservations = reservations;
        }
    }
}
