namespace BLL.Data.Employee.Reservation;

public interface IReservationService
{
    List<Entities.Reservation> GetAllReservations();

    Entities.Reservation? GetReservationById(Guid guid);

    Entities.Reservation CreateReservation(Entities.Reservation reservation);

    Entities.Reservation UpdateReservation(Entities.Reservation reservation);

    void DeleteReservation(Guid guid);

    List<Entities.Reservation> GetFilteredReservationsByEmployeeId(Guid employeeId, DateTime dateFrom, DateTime dateTo);
    List<Entities.Reservation> GetFilteredReservations(DateTime dateStart, DateTime dateEnd);
}