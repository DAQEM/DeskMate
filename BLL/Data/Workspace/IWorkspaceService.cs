﻿using BLL.Entities;

namespace BLL.Data;

public interface IWorkspaceService
{
    List<Workspace> GetAllWorkspaces();

    List<Workspace> GetAllWorkspacesWithCharacteristics();

    List<Workspace> GetWorkspacesByFloorId(Guid modelSelectedFloorId);

    List<Workspace> GetWorkspacesWithCharacteristicsAndReservations();

    Workspace GetWorkspaceById(Guid workspaceId);

    List<Workspace> GetWorkspacesWithCharacteristicsAndReservationsByFloorId(Guid floorId);

    List<Workspace> GetWorkspacesWithCharacteristicsAndReservationsAndRoomAndFloorAndLocation();

    Workspace GetWorkspaceWithCharateristicsAndReservationsAndRoomAndFloorByWorkplaceId(Guid workspaceId);

    List<Reservation> GetReservationsAndUserFromCurrentDate(Workspace workspace);
}