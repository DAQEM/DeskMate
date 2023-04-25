using BLL.Entities;

namespace BLL.Data;

public interface IWorkspaceService
{
    List<Workspace> GetAllWorkspaces();

    List<Workspace> GetAllWorkspacesWithCharacteristics();

    List<Workspace> GetWorkspacesByFloorId(Guid modelSelectedFloorId);

    List<Workspace> GetWorkspacesWithCharacteristicsAndReservations();
}