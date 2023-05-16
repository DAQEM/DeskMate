using BLL.DTOs;

namespace BLL.Entities;

public class Workspace
{
    private readonly List<Characteristic> _characteristics;
    private readonly Guid _id;
    private readonly string _name;
    private readonly List<Reservation> _reservations;
    private readonly Room _room;
    private bool _occupied = false;

    public Workspace(Guid? id = null, string name = "",
        List<Characteristic>? characteristics = null, List<Reservation>? reservations = null, Room? room = null)
    {
        _id = id ?? Guid.Empty;
        _name = name;
        _characteristics = characteristics ?? new List<Characteristic>();
        _reservations = reservations ?? new List<Reservation>();
        _room = room;
    }

    public Guid Id => _id;
    public string Name => _name;
    public List<Characteristic> Characteristics => _characteristics;
    public List<Reservation> Reservations => _reservations;
    public Room Room => _room;

    public bool Occupied
    {
        get => _occupied;
        set => _occupied = value;
    }

    public void SetCharacteristics(List<Characteristic> characteristics)
    {
        _characteristics.Clear();
        _characteristics.AddRange(characteristics);
    }

    public WorkspaceDTO ToWorkspaceDTO()
    {
        return new WorkspaceDTO
        {
            Id = _id,
            Name = _name,
            workspaceCharacteristicsDTOs = GetWorkspaceCharacteristicsDTOs(),
            reservationDTOs = _reservations.Select(r => r.ToReservationDTO()).ToList()
        };
    }

    private List<WorkspaceCharacteristicsDTO> GetWorkspaceCharacteristicsDTOs()
    {
        return _characteristics.Select(c => new WorkspaceCharacteristicsDTO
            {
                WorkspaceId = _id,
                CharacteristicId = c.Id,
                Amount = c.Amount
            }
        ).ToList();
    }

    public bool IsOccupied(DateTime startDate, DateTime endDate)
    {
        return _reservations.Any(r => r.IsOccupied(startDate, endDate));
    }
}