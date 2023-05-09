using BLL.Data.Employee.Reservation;
using BLL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Reservation;

namespace MVC.Controllers;

[Authorize]
[Route("Reservation")]
public class ReservationController : BaseController<ReservationController>
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        List<Reservation> reservations = _reservationService.GetAllReservations();
        return View(new ReservationsModel { Reservations = reservations });
    }

    [HttpPost]
    [Route("delete/{guid}")]
    public IActionResult Delete(Guid guid)
    {
        _reservationService.DeleteReservation(guid);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("edit{guid}")]
    public IActionResult Edit(Guid guid)
    {
        Reservation reservation = _reservationService.GetReservationById(guid);
        return View(reservation);
    }
}