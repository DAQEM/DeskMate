using BLL.Data;
using BLL.Data.Employee.Reservation;
using BLL.Data.Floor;
using BLL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Reservation;

namespace MVC.Controllers;

[Authorize]
[Route("Reservation")]
public class ReservationController : BaseController<ReservationController>
{
    private readonly IFloorService _floorService;
    private readonly ILocationService _locationService;
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService, IFloorService floorService,
        ILocationService locationService)
    {
        _reservationService = reservationService;
        _floorService = floorService;
        _locationService = locationService;
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
        EditReservationModel model = new();
        Reservation? reservation =
            _reservationService.GetReservationWithEmployeeWorkspaceRoomFloorAndLocationById(guid);

        if (reservation != null)
        {
            model.DateTimeSelectionModel = new DateTimeSelectionModel
            {
                Date = reservation.StartDate,
                StartTime = reservation.StartDate,
                EndTime = reservation.EndDate
            };
        }

        return View(model);
    }

    [HttpPost]
    [Route("edit/{guid}")]
    public IActionResult Edit(Guid guid, EditReservationModel model)
    {
        if (ModelState.IsValid)
        {
            Reservation? reservation =
                _reservationService.GetReservationWithEmployeeWorkspaceRoomFloorAndLocationById(guid);

            if (reservation != null)
            {
                _reservationService.UpdateReservation(new Reservation(
                    reservation.Id,
                    model.DateTimeSelectionModel.Date.Add(model.DateTimeSelectionModel.StartTime.TimeOfDay),
                    model.DateTimeSelectionModel.Date.Add(model.DateTimeSelectionModel.EndTime.TimeOfDay),
                    reservation.Employee,
                    reservation.Workspace
                ));
                return RedirectToAction("Index");
            }
        }

        return View(model);
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