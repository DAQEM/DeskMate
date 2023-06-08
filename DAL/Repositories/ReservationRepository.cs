using BLL.Data.Employee.Reservation;
using BLL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly DeskMateContext _context;

    public ReservationRepository(DeskMateContext context)
    {
        _context = context;
    }

    public List<ReservationDTO> GetAllReservations()
    {
        return _context.reservation
            .Include(r => r.userDTO)
            .Include(r => r.WorkspaceDTO)
            .Select(r => new ReservationDTO
            {
                Id = r.Id,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                UserId = r.UserId,
                WorkspaceId = r.WorkspaceId,
                userDTO = new UserDTO
                {
                    Id = r.userDTO.Id,
                    Name = r.userDTO.Name
                },
                WorkspaceDTO = new WorkspaceDTO
                {
                    Id = r.WorkspaceDTO.Id,
                    Name = r.WorkspaceDTO.Name
                }
            }).ToList();
    }

    public ReservationDTO? GetReservationById(Guid guid)
    {
        return _context.reservation
            .FirstOrDefault(r => r.Id == guid);
    }

    public ReservationDTO? GetReservationWithEmployeeWorkspaceRoomFloorAndLocationById(Guid guid)
    {
        return _context.reservation
            .Include(r => r.userDTO)
            .Include(r => r.WorkspaceDTO)
            .ThenInclude(w => w.roomDTO)
            .ThenInclude(r => r.floorDTO)
            .ThenInclude(f => f.locationDTO)
            .FirstOrDefault(r => r.Id == guid);
    }

    public ReservationDTO CreateReservation(ReservationDTO reservation)
    {
        _context.reservation.Add(reservation);

        _context.SaveChanges();

        return reservation;
    }

    public void UpdateReservation(ReservationDTO updatedReservation)
    {
        ReservationDTO? existingReservation = _context.reservation.Find(updatedReservation.Id);

        if (existingReservation != null)
        {
            _context.Entry(existingReservation).State = EntityState.Detached;

            _context.Attach(updatedReservation);
            _context.Entry(updatedReservation).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }

    public void DeleteReservation(Guid guid)
    {
        ReservationDTO? reservation = _context.reservation
            .FirstOrDefault(r => r.Id == guid);

        if (reservation != null)
        {
            _context.reservation.Remove(reservation);
            _context.SaveChanges();
        }
    }

    public List<ReservationDTO> GetFilteredReservationsByEmployeeId(Guid employeeId, DateTime dateFrom, DateTime dateTo)
    {
        return _context.reservation
            .Include(r => r.userDTO)
            .Include(r => r.WorkspaceDTO)
            .Where(r => r.userDTO.Id == employeeId && r.StartDate >= dateFrom && r.EndDate <= dateTo)
            .ToList();
    }

    public List<ReservationDTO> GetFilteredReservations(DateTime dateStart, DateTime dateEnd)
    {
        return _context.reservation
            .Include(r => r.userDTO)
            .Include(r => r.WorkspaceDTO)
            .Where(r => r.StartDate >= dateStart && r.EndDate <= dateEnd)
            .ToList();
    }

    public List<ReservationDTO> GetRunningReservationsForWorkspace(Guid workspaceId, DateTime dateFrom, DateTime dateTo)
    {
        return _context.reservation
            .Include(r => r.userDTO)
            .Include(r => r.WorkspaceDTO)
            .Where(r =>
                r.WorkspaceId == workspaceId &&
                (
                    (r.StartDate >= dateFrom && r.StartDate <= dateTo) || // Reservation starts within the range
                    (r.EndDate >= dateFrom && r.EndDate <= dateTo) || // Reservation ends within the range
                    (r.StartDate < dateFrom && r.EndDate > dateTo) // Reservation spans the entire range
                )
            )
            .ToList();
    }
}