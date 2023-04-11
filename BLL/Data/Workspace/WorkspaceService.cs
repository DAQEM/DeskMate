using BLL.Entities;

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
}