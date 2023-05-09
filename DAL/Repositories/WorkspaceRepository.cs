using BLL.Data;
using BLL.DTOs;
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

    public List<WorkplaceDTO> GetWorkspacesByFloorId(Guid floorId)
    {
        return _context.workspace
            .Where(w => w.roomDTO.FloorId == floorId)
            .ToList();
    }

    public WorkplaceDTO? GetWorkspaceById(Guid workspaceId)
    {
        return _context.workspace
            .FirstOrDefault(w => w.Id == workspaceId);
    }
}