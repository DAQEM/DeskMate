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
    public WorkplaceDTO workplaceDTO { get; set; }

    public Reservation ToReservation()
    {
        return new Reservation(Id, StartDate, EndDate, userDTO.ToEmployee(), workplaceDTO.ToWorkspace());
    }

    public Reservation ToSmallReservation()
    {
        return new Reservation(Id, StartDate, EndDate);
    }
}