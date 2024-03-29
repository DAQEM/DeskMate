﻿using BLL.Data.Floor;
using BLL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class FloorRepository : IFloorRepository
{
    private readonly DeskMateContext _context;

    public FloorRepository(DeskMateContext context)
    {
        _context = context;
    }

    public List<FloorDTO> GetAllFloors()
    {
        return _context.floor.ToList();
    }

    public List<FloorDTO> GetAllFloorsByLocationId(Guid locationId)
    {
        return _context.floor.Where(f => f.LocationId == locationId).ToList();
    }

    public FloorDTO? GetFloorWithRoomsAndWorkspacesWithOccupancyById(Guid id)
    {
        return _context.floor
            .Include(f => f.roomDTO)
            .ThenInclude(r => r.workplaceDTO)
            .ThenInclude(r => r.reservationDTOs)
            .Include(f => f.roomDTO)
            .ThenInclude(r => r.workplaceDTO)
            .ThenInclude(r => r.workspacePlacementDTO)
            .FirstOrDefault(f => f.Id == id);
    }
}