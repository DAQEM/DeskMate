using System.ComponentModel.DataAnnotations.Schema;
using BLL.Entities;

namespace BLL.DTOs;

public class WorkplaceDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName = "varchar(200)")] public string Name { get; set; }
    public Guid RoomId { get; set; }
    public RoomDTO roomDTO { get; set; }
    public ICollection<ReservationDTO> reservationDTOs { get; set; }
    public ICollection<WorkplaceCharacteristicsDTO> workplaceCharacteristicsDTOs { get; set; }

    public Workspace ToWorkspace()
    {
        return new Workspace(
            Id,
            Name,
            reservations: new List<Reservation>(),
            characteristics: new List<Characteristic>());
    }
}