﻿using BLL.Entities;

namespace MVC.Models;

public class ReservationModel
{
    public Dictionary<BLL.Entities.Workspace, Employee> Reservations { get; set; } = new();
}