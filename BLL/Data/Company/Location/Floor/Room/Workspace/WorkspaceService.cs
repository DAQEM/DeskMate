using BLL.Entities;

namespace BLL.Data;

public class WorkspaceService : IWorkspaceService
{
    private readonly IWorkspaceRepository _workspaceRepository;
    private readonly ICharacteristicService _characteristicService;
    
    
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
}