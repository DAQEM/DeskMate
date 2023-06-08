using BLL.DTOs;
using BLL.Entities;
using BLL.Exception;

namespace BLL.Data;

public class WorkspaceService : IWorkspaceService
{
    private readonly ICharacteristicService _characteristicService;
    private readonly IWorkspaceRepository _workspaceRepository;


    public WorkspaceService(IWorkspaceRepository workspaceRepository,
        ICharacteristicService characteristicService)
    {
        _workspaceRepository = workspaceRepository;
        _characteristicService = characteristicService;
    }

    public List<Workspace> GetAllWorkspaces()
    {
        return _workspaceRepository.GetAllWorkspaces();
    }

    public List<Workspace> GetAllWorkspacesWithCharacteristics()
    {
        List<Workspace> workspaces = _workspaceRepository.GetAllWorkspaces();

        foreach (Workspace workspace in workspaces)
        {
            workspace.SetCharacteristics(_characteristicService.GetCharacteristicsForWorkspace(workspace));
        }

        return workspaces;
    }

    public List<Workspace> GetWorkspacesByFloorId(Guid modelSelectedFloorId)
    {
        return _workspaceRepository.GetWorkspacesByFloorId(modelSelectedFloorId)
            .Select(w => w.ToWorkspace())
            .ToList();
    }

    public Workspace GetWorkspaceById(Guid workspaceId)
    {
        WorkspaceDTO? workspace = _workspaceRepository.GetWorkspaceById(workspaceId);
        if (workspace == null)
        {
            throw new ServiceException(nameof(Workspace), workspaceId.ToString());
        }

        return workspace.ToWorkspace();
    }

    public List<Workspace> GetWorkspacesWithCharacteristicsAndReservations()
    {
        List<Workspace> workspaces = _workspaceRepository.GetWorkspacesWithCharacteristicsAndReservations()
            .Select(w => w.ToWorkspaceWithCharacteristicAndReservation())
            .ToList();

        foreach (Workspace workspace in workspaces)
        {
            if (workspace.Reservations.Where(r => DateTime.Now >= r.StartDate && DateTime.Now < r.EndDate).Any())
            {
                workspace.Occupied = true;
            }
        }

        return workspaces;
    }

    public List<Workspace> GetWorkspacesWithCharacteristicsAndReservationsByFloorId(Guid floorId)
    {
        List<Workspace> workspaces = _workspaceRepository
            .GetWorkspacesWithCharacteristicsAndReservationsByFloorId(floorId)
            .Select(w => w.ToWorkspaceWithCharacteristicAndReservation())
            .ToList();

        foreach (Workspace workspace in workspaces)
        {
            if (!workspace.IsOccupied(DateTime.Now, DateTime.Now))
            {
                workspace.Occupied = true;
            }
        }

        return workspaces;
    }

    public List<Workspace> GetWorkspacesWithCharacteristicsAndReservationsAndRoomAndFloorAndLocation()
    {
        List<Workspace> workspaces = _workspaceRepository
            .GetWorkspacesWithCharacteristicsAndReservationsAndRoomAndFloorAndLocation()
            .Select(w => w.ToWorkspaceWithCharacteristicAndReservationAndRoomAndFloorAndLocation())
            .ToList();


        foreach (Workspace workspace in workspaces)
        {
            if (workspace.Reservations.Any(r => DateTime.Now >= r.StartDate && DateTime.Now < r.EndDate))
            {
                workspace.Occupied = true;
            }
        }

        return workspaces;
    }

    public Workspace GetWorkspaceWithCharateristicsAndReservationsAndRoomAndFloorByWorkplaceId(Guid workspaceId)
    {
        List<Workspace> workspaces = _workspaceRepository
            .GetWorkspacesWithCharacteristicsAndReservationsAndRoomAndFloor()
            .Select(w => w.ToWorkspaceWithCharacteristicAndReservationAndRoomAndFloor())
            .ToList();
        Workspace workspace = workspaces.Where(w => w.Id == workspaceId).FirstOrDefault();
        return workspace;
    }

    public List<Reservation> GetReservationsAndUserFromCurrentDate(Workspace workspace)
    {
        List<Reservation> reservations = workspace.Reservations.Where(r => r.EndDate > DateTime.Now).ToList();


        return reservations;
    }
}