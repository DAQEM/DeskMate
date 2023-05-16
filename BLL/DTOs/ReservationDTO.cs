using BLL.Entities;

namespace BLL.DTOs;

public class ReservationDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid UserId { get; set; }
    public Guid WorkspaceId { get; set; }

    public UserDTO userDTO { get; set; }
    public WorkspaceDTO WorkspaceDTO { get; set; }

    public Reservation ToReservation()
    {
        return new Reservation(
            Id,
            StartDate,
            EndDate,
            userDTO.ToEmployee(),
            WorkspaceDTO.ToWorkspace());
    }

    public Reservation ToReservationWithSmallEmployeeAndWorkspace()
    {
        return new Reservation(
            Id,
            StartDate,
            EndDate,
            userDTO.ToSmallEmployee(),
            WorkspaceDTO.ToSmallWorkspace());
    }

    public Reservation ToSmallReservation()
    {
        return new Reservation(Id, StartDate, EndDate);
    }
}