namespace BLL.DTOs
{
    public class WorkplaceCharacteristicsDTO
    {
        public Guid WorkspaceId { get; set; }
        public Guid CharacteristicId { get; set; }
        public int Amount { get; set; }
        public WorkplaceDTO workplaceDTO { get; set; }
        public CharacteristicDTO characteristicDTO { get; set; }
    }
}