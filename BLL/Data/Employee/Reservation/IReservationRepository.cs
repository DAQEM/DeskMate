using BLL.DTOs;

namespace BLL.Data.Employee.Reservation;

public interface IReservationRepository
{
    List<ReservationDTO> GetAllReservations();

    ReservationDTO? GetReservationById(Guid guid);

    ReservationDTO CreateReservation(ReservationDTO reservation);

    ReservationDTO UpdateReservation(ReservationDTO reservation);

    void DeleteReservation(Guid guid);
    List<ReservationDTO> GetFilteredReservationsByEmployeeId(Guid employeeId, DateTime dateFrom, DateTime dateTo);
    List<ReservationDTO> GetFilteredReservations(DateTime dateStart, DateTime dateEnd);
}