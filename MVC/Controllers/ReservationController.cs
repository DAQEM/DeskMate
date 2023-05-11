using BLL.Data.Employee.Reservation;
using BLL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        return View();
    }

    [HttpPost]
    [Route("delete/{guid}")]
    public IActionResult Delete(Guid guid)
    {
        _reservationService.DeleteReservation(guid);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("edit/{guid}")]
    public IActionResult Edit(Guid guid)
    {
        Reservation reservation = _reservationService.GetReservationById(guid);
        return View(reservation);
    }

    [HttpGet]
    [Route("/api/filtered/reservation")]
    public IActionResult GetFilteredReservations(string dateFrom, string dateTo)
    {
        List<Reservation> reservations =
            _reservationService.GetFilteredReservations(DateTime.Parse(dateFrom), DateTime.Parse(dateTo));
        return new JsonResult(new { reservations });
    }

    [HttpGet]
    [Route("/api/filtered/reservation/{employeeId}")]
    public IActionResult GetFilteredReservationsByEmployeeId(string employeeId, string dateFrom, string dateTo)
    {
        if (!Guid.TryParse(employeeId, out Guid employeeGuid))
        {
            return new JsonResult(new { error = "Invalid employee id" });
        }

        List<Reservation> reservations =
            _reservationService.GetFilteredReservationsByEmployeeId(employeeGuid, DateTime.Parse(dateFrom),
                DateTime.Parse(dateTo)).OrderBy(reservation => reservation.StartDate).ToList();
        return new JsonResult(new { reservations });
    }
}