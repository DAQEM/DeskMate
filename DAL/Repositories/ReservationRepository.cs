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
            .Include(r => r.WorkspaceDto)
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
                WorkspaceDto = new WorkspaceDTO
                {
                    Id = r.WorkspaceDto.Id,
                    Name = r.WorkspaceDto.Name
                }
            }).ToList();
    }

    public ReservationDTO? GetReservationById(Guid guid)
    {
        return _context.reservation
            .FirstOrDefault(r => r.Id == guid);
    }

    public ReservationDTO CreateReservation(ReservationDTO reservation)
    {
        _context.reservation.Add(reservation);

        _context.SaveChanges();

        return reservation;
    }

    public ReservationDTO UpdateReservation(ReservationDTO reservation)
    {
        _context.Update(reservation);

        _context.SaveChanges();

        return reservation;
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
}