﻿using BLL.Entities;

namespace BLL.Data;

public interface IWorkspaceService
{
    List<Workspace> GetAllWorkspaces();
    
    List<Workspace> GetAllWorkspacesWithCharacteristics();
}