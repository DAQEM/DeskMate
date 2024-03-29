﻿using System.ComponentModel.DataAnnotations.Schema;
using BLL.Entities;

namespace BLL.DTOs;

public class RoomDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName = "varchar(200)")] public string Name { get; set; }
    public Guid FloorId { get; set; }
    public FloorDTO floorDTO { get; set; }
    public ICollection<WorkspaceDTO> workplaceDTO { get; set; }

    public Room ToRoom()
    {
        return new Room(
            Id,
            Name,
            new List<Workspace>(),
            floorDTO.ToFloor());
    }

    public Room ToRoomWithFloorAndLocation()
    {
        return new Room(
            Id,
            Name,
            new List<Workspace>(),
            floorDTO.ToFloorWithLocation());
    }

    public Room ToRoomWithWorkspaces()
    {
        return new Room(
            Id,
            Name,
            workplaceDTO.Select(w => w.ToWorkspace()).ToList());
    }

    public Room ToRoomWithWorkspacesAndReservationsAndPlacement()
    {
        return new Room(
            Id,
            Name,
            workplaceDTO.Select(w => w.ToWorkspaceWithReservationsAndPlacement()).ToList());
    }
}