using BLL.DTOs;
using BLL.Entities;

namespace BLL.Data;

public interface IWorkspaceRepository
{
    List<Workspace> GetAllWorkspaces();
    List<WorkspaceDTO> GetWorkspacesByFloorId(Guid floorId);
    WorkspaceDTO? GetWorkspaceById(Guid workspaceId);
    List<WorkspaceDTO> GetWorkspacesWithCharacteristicsAndReservations();
    List<WorkspaceDTO> GetWorkspacesWithCharacteristicsAndReservationsByFloorId(Guid floorId);
}