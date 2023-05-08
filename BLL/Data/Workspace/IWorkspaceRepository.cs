using BLL.DTOs;
using BLL.Entities;

namespace BLL.Data;

public interface IWorkspaceRepository
{
    List<Workspace> GetAllWorkspaces();

    List<WorkspaceDTO> GetWorkspacesByFloorId(Guid floorId);
    List<WorkspaceDTO> GetWorkspacesWithCharacteristicsAndReservations();

    WorkspaceDTO? GetWorkspaceById(Guid workspaceId);

}