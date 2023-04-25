namespace BLL.Data.Employee.Reservation;

public interface IReservationService
{
    List<Entities.Reservation> GetAllReservations();

    Entities.Reservation? GetReservationById(Guid guid);

    Entities.Reservation CreateReservation(Entities.Reservation reservation);

    Entities.Reservation UpdateReservation(Entities.Reservation reservation);

    Entities.Reservation? DeleteReservation(Guid guid);
}