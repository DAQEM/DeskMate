using BLL.DTOs;
using BLL.Entities;

namespace BLL.Data;

public interface IWorkspaceRepository
{
    List<Workspace> GetAllWorkspaces();
    List<WorkplaceDTO> GetWorkspacesByFloorId(Guid floorId);
}