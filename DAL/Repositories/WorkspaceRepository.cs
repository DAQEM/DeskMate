using BLL.Data;
using BLL.Entities;

namespace BLL.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    public List<Workspace> GetAllWorkspaces()
    {
        //TODO: Get workspaces from database
        //These are just some examples
        return new List<Workspace>()
        {
            new(name: "Workspace 1"),
            new(name: "Workspace 2"),
            new(name: "Workspace 3"),
            new(name: "Workspace 4"),
            new(name: "Workspace 5"),
            new(name: "Workspace 6"),
            new(name: "Workspace 7"),
            new(name: "Workspace 8"),
            new(name: "Workspace 9"),
            new(name: "Workspace 10")
        };
    }
}