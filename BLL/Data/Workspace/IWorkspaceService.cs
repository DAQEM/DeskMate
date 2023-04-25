using BLL.Entities;

namespace BLL.Data;

public interface IWorkspaceService
{
    List<Workspace> GetAllWorkspaces();

    List<Workspace> GetAllWorkspacesWithCharacteristics();

    List<Workspace> GetWorkspacesByFloorId(Guid modelSelectedFloorId);
<<<<<<< HEAD

    List<Workspace> GetWorkspacesWithCharacteristicsAndReservations();
=======
    Workspace GetWorkspaceById(Guid workspaceId);
>>>>>>> 20aeecdd64fcdeed72d551ff698610c39029a503
}