using System.Reflection.Metadata;
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

    public Workspace GetWorkspaceById(Guid workspaceId)
    {
        throw new NotImplementedException();
    }

    public List<Workspace> GetWorkspacesByFloorId(Guid modelSelectedFloorId)
	{
		return _workspaceRepository.GetWorkspacesByFloorId(modelSelectedFloorId)
			.Select(w => w.ToWorkspace())
			.ToList();
	}

	public List<Workspace> GetWorkspacesWithCharacteristicsAndReservations()
	{
	  List<Workspace> workspaces = _workspaceRepository.GetWorkspacesWithCharacteristicsAndReservations()
		   .Select(w => w.ToWorkspaceWithCharacteristicAndReservation())
		   .ToList();

      foreach ( Workspace workspace in workspaces)
      {
          if (workspace.Reservations.Where(r => DateTime.Now >= r.StartDate && DateTime.Now < r.EndDate).Any())
          {
				workspace.Occupied = true;
          }
      }

      return workspaces;
    }


}