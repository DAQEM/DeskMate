using BLL.DTOs;

namespace BLL.Data.Employee.Reservation;

public interface IReservationRepository
{
    List<ReservationDTO> GetAllReservations();

    ReservationDTO? GetReservationById(Guid guid);

    ReservationDTO CreateReservation(ReservationDTO reservation);

    ReservationDTO UpdateReservation(ReservationDTO reservation);

    void DeleteReservation(Guid guid);
}