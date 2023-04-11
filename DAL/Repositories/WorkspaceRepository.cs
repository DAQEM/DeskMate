using BLL.Data;
using BLL.Entities;

namespace DAL.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly DeskMateContext _context;

    public WorkspaceRepository(DeskMateContext context)
    {
        _context = context;
    }

    public List<Workspace> GetAllWorkspaces()
    {
        return _context.workspace
            .Select(w => w.ToWorkspace())
            .ToList();
    }
}