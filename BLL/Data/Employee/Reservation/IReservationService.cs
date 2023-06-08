namespace BLL.Data.Employee.Reservation;

public interface IReservationService
{
    List<Entities.Reservation> GetAllReservations();

    Entities.Reservation? GetReservationById(Guid guid);

    Entities.Reservation? GetReservationWithEmployeeWorkspaceRoomFloorAndLocationById(Guid guid);

    Entities.Reservation CreateReservation(Entities.Reservation reservation);

    void UpdateReservation(Entities.Reservation reservation);

    void DeleteReservation(Guid guid);

    List<Entities.Reservation> GetFilteredReservationsByEmployeeId(Guid employeeId, DateTime dateFrom, DateTime dateTo);
    List<Entities.Reservation> GetFilteredReservations(DateTime dateStart, DateTime dateEnd);

    List<Entities.Reservation> GetRunningReservationsForWorkspace(Guid workspaceId, DateTime dateFrom, DateTime dateTo);
}