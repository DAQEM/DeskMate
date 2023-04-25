using BLL.DTOs;
using BLL.Entities;

namespace BLL.Data;

public interface IWorkspaceRepository
{
    List<Workspace> GetAllWorkspaces();
<<<<<<< HEAD
    List<WorkspaceDTO> GetWorkspacesByFloorId(Guid floorId);
    List<WorkspaceDTO> GetWorkspacesWithCharacteristicsAndReservations();
=======
    List<WorkplaceDTO> GetWorkspacesByFloorId(Guid floorId);
    WorkplaceDTO? GetWorkspaceById(Guid workspaceId);
>>>>>>> 20aeecdd64fcdeed72d551ff698610c39029a503
}