﻿namespace BLL.DTOs
{
    public class WorkspaceCharacteristicsDTO
    {
        public Guid WorkspaceId { get; set; }
        public Guid CharacteristicId { get; set; }
        public int Amount { get; set; }
        public WorkspaceDTO WorkspaceDto { get; set; }
        public CharacteristicDTO characteristicDTO { get; set; }
    }
}