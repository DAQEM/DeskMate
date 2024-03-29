﻿using BLL.Entities;

namespace BLL.Data;

public interface ILocationService
{
    List<Location> GetAllLocations();
    Location? GetLocationById(Guid locationId);
}