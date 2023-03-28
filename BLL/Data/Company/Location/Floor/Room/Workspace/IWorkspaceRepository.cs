using BLL.Entities;

namespace BLL.Data;

public interface IWorkspaceRepository
{
    List<Workspace> GetAllWorkspaces();
}