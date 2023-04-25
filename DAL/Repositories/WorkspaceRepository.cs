using BLL.Data;
using BLL.DTOs;
using BLL.Entities;
using Microsoft.EntityFrameworkCore;

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

    public List<WorkspaceDTO> GetWorkspacesByFloorId(Guid floorId)
    {
        return _context.workspace
            .Where(w => w.roomDTO.FloorId == floorId)
            .ToList();
    }

<<<<<<< HEAD
    public List<WorkspaceDTO> GetWorkspacesWithCharacteristicsAndReservations()
    {
	    return _context.workspace
		    .Include(w => w.workspaceCharacteristicsDTOs)
		    .ThenInclude(wc => wc.characteristicDTO)
		    .Include(w => w.reservationDTOs)
		    .ToList();
=======
    public WorkplaceDTO? GetWorkspaceById(Guid workspaceId)
    {
        return _context.workspace
            .FirstOrDefault(w => w.Id == workspaceId);
>>>>>>> 20aeecdd64fcdeed72d551ff698610c39029a503
    }
}