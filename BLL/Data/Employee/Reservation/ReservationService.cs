﻿namespace BLL.Data.Employee.Reservation;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public List<Entities.Reservation> GetAllReservations()
    {
        return _reservationRepository.GetAllReservations()
            .Select(r => r.ToReservation())
            .ToList();
    }

    public Entities.Reservation? GetReservationById(Guid guid)
    {
        return _reservationRepository.GetReservationById(guid)?.ToReservation();
    }

    public Entities.Reservation CreateReservation(Entities.Reservation reservation)
    {
        return _reservationRepository.CreateReservation(reservation.ToSmallReservationDTO()).ToSmallReservation();
    }

    public Entities.Reservation UpdateReservation(Entities.Reservation reservation)
    {
        return _reservationRepository.UpdateReservation(reservation.ToSmallReservationDTO()).ToSmallReservation();
    }

    public void DeleteReservation(Guid guid)
    {
        _reservationRepository.DeleteReservation(guid);
    }

    public List<Entities.Reservation> GetFilteredReservationsByEmployeeId(Guid employeeId, DateTime dateFrom,
        DateTime dateTo)
    {
        return _reservationRepository.GetFilteredReservationsByEmployeeId(employeeId, dateFrom, dateTo)
            .Select(r => r.ToReservationWithSmallEmployeeAndWorkspace())
            .ToList();
    }

    public List<Entities.Reservation> GetFilteredReservations(DateTime dateStart, DateTime dateEnd)
    {
        return _reservationRepository.GetFilteredReservations(dateStart, dateEnd)
            .Select(r => r.ToReservationWithSmallEmployeeAndWorkspace())
            .ToList();
    }
}