using System.ComponentModel.DataAnnotations.Schema;
using BLL.Entities;

namespace BLL.DTOs;

public class FloorDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName = "varchar(200)")] public string Name { get; set; }
    public int Number { get; set; }
    public Guid LocationId { get; set; }
    public ICollection<RoomDTO> roomDTO { get; set; }
    public LocationDTO locationDTO { get; set; }

    public Floor ToFloor()
    {
        return new Floor(
            Id,
            Name,
            Number,
            new Floorplan(),
            new List<Room>(),
            new Location(LocationId));
    }

    public Floor ToFloorWithLocation()
    {
        return new Floor(
            Id,
            Name,
            Number,
            new Floorplan(),
            new List<Room>(),
            locationDTO.ToLocation());
    }

    public Floor ToFloorWithRoomsAndWorkspaces()
    {
        return new Floor(
            Id,
            Name,
            Number,
            new Floorplan(),
            roomDTO.Select(r => r.ToRoomWithWorkspaces()).ToList());
    }

    public Floor ToFloorWithRoomsWorkspacesAndReservationsAndPlacement()
    {
        return new Floor(
            Id,
            Name,
            Number,
            new Floorplan(),
            roomDTO.Select(r => r.ToRoomWithWorkspacesAndReservationsAndPlacement()).ToList(),
            new Location(LocationId));
    }
}