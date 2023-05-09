using BLL.Data.Employee.Reservation;
using BLL.DTOs;

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
        return _context.reservation.ToList();
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

    public ReservationDTO? DeleteReservation(Guid guid)
    {
        ReservationDTO? reservation = _context.reservation
            .FirstOrDefault(r => r.Id == guid);

        if (reservation != null)
        {
            _context.reservation.Remove(reservation);

            _context.SaveChanges();
        }

        return reservation;
    }
}