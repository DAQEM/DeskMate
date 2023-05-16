using BLL.DTOs;

namespace BLL.Entities;

public class Reservation
{
    private readonly Employee _employee;
    private readonly DateTime _endDate;
    private readonly Guid _id;
    private readonly DateTime _startDate;
    private readonly Workspace _workspace;

    public Reservation(Guid? id = null, DateTime? startDate = null, DateTime? endDate = null,
        Employee? employee = null, Workspace? workspace = null)
    {
        _id = id ?? Guid.Empty;
        _startDate = startDate ?? DateTime.MinValue;
        _endDate = endDate ?? DateTime.MinValue;
        _employee = employee ?? new Employee();
        _workspace = workspace ?? new Workspace();
    }

    public Guid Id => _id;
    public DateTime StartDate => _startDate;
    public DateTime EndDate => _endDate;
    public Employee Employee => _employee;
    public Workspace Workspace => _workspace;

    public bool IsValid()
    {
        return _startDate < _endDate;
    }

    public bool IsCurrentlyActive()
    {
        return _startDate < DateTime.Now && _endDate > DateTime.Now;
    }

    public bool IsCurrentlyExpired()
    {
        return _endDate < DateTime.Now;
    }

    public bool IsActiveOn(DateTime date)
    {
        return _startDate < date && _endDate > date;
    }

    public ReservationDTO ToReservationDTO()
    {
        return new ReservationDTO
        {
            Id = _id,
            StartDate = _startDate,
            EndDate = _endDate,
            UserId = _employee.Id,
            WorkspaceId = _workspace.Id,

            userDTO = _employee.ToUserDTO(),
            WorkspaceDTO = _workspace.ToWorkspaceDTO()
        };
    }

    public ReservationDTO ToSmallReservationDTO()
    {
        return new ReservationDTO
        {
            Id = _id,
            StartDate = _startDate,
            EndDate = _endDate,
            UserId = _employee.Id,
            WorkspaceId = _workspace.Id
        };
    }

    public bool IsOccupied(DateTime startDate, DateTime endDate)
    {
        return _startDate < endDate && _endDate > startDate;
    }
}