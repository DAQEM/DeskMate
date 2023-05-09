﻿using System.ComponentModel.DataAnnotations.Schema;
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
		    Name,
            new List<Characteristic>(),
            new List<Reservation>());
    }

	//TODO: Add employee
	//TODO: Workspace
    public Workspace ToWorkspaceWithCharacteristicAndReservation()
    {


		Workspace workspace = new Workspace(
		    Id,
		    Name,
		    new List<Characteristic>(),
		    new List<Reservation>());

		foreach (var reservationDTO in reservationDTOs)
		{
			Reservation reservation = new Reservation(
				reservationDTO.Id,
				reservationDTO.StartDate,
				reservationDTO.EndDate);

				workspace.Reservations.Add(reservation);
		}

		foreach (WorkspaceCharacteristicsDTO workspacecharacteristicDTO in workspaceCharacteristicsDTOs)
		{
			Characteristic characteristic = new Characteristic(
				workspacecharacteristicDTO.characteristicDTO.Type,
			    workspacecharacteristicDTO.characteristicDTO.Id,
				workspacecharacteristicDTO.Amount);

			workspace.Characteristics.Add(characteristic);
		}


		return workspace;


    }
}