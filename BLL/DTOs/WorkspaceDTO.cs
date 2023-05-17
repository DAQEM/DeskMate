using System.ComponentModel.DataAnnotations.Schema;
using BLL.Entities;

namespace BLL.DTOs;

public class WorkspaceDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName = "varchar(200)")] public string Name { get; set; }
    public Guid RoomId { get; set; }
    public RoomDTO roomDTO { get; set; }
    public ICollection<ReservationDTO> reservationDTOs { get; set; }
    public ICollection<WorkspaceCharacteristicsDTO> workspaceCharacteristicsDTOs { get; set; }

    public Workspace ToWorkspace()
    {
        return new Workspace(
            Id,
            Name);
    }

    public Workspace ToWorkspaceWithCharacteristicAndReservation()
    {
        Workspace workspace = new(
            Id,
            Name);

        foreach (ReservationDTO reservationDTO in reservationDTOs)
        {
            Reservation reservation = new(
                reservationDTO.Id,
                reservationDTO.StartDate,
                reservationDTO.EndDate);

            workspace.Reservations.Add(reservation);
        }

        foreach (WorkspaceCharacteristicsDTO workspacecharacteristicDTO in workspaceCharacteristicsDTOs)
        {
            Characteristic characteristic = new(
                workspacecharacteristicDTO.characteristicDTO.Type,
                workspacecharacteristicDTO.characteristicDTO.Id,
                workspacecharacteristicDTO.Amount);

            workspace.Characteristics.Add(characteristic);
        }


        return workspace;
    }

    public Workspace ToWorkspaceWithCharacteristicAndReservationAndRoomAndFloor()
    {
        Workspace workspace = new(
            Id,
            Name,
            room: roomDTO.ToRoom());


        foreach (ReservationDTO reservationDTO in reservationDTOs)
        {
            Reservation reservation = new(
                reservationDTO.Id,
                reservationDTO.StartDate,
                reservationDTO.EndDate);

            workspace.Reservations.Add(reservation);
        }

        foreach (WorkspaceCharacteristicsDTO workspacecharacteristicDTO in workspaceCharacteristicsDTOs)
        {
            Characteristic characteristic = new(
                workspacecharacteristicDTO.characteristicDTO.Type,
                workspacecharacteristicDTO.characteristicDTO.Id,
                workspacecharacteristicDTO.Amount);

            workspace.Characteristics.Add(characteristic);
        }

        return workspace;
    }

    public Workspace ToSmallWorkspace()
    {
        return new Workspace(
            Id,
            Name);
    }

    public Workspace? ToWorkspaceWithRoomFloorAndLocation()
    {
        return new Workspace(
            Id,
            Name,
            room: roomDTO.ToRoomWithFloorAndLocation());
    }

    public Workspace ToWorkspaceWithReservations()
    {
        return new Workspace(
            Id,
            Name,
            reservations: reservationDTOs.Select(r => r.ToSmallReservation()).ToList()
        );
    }
}