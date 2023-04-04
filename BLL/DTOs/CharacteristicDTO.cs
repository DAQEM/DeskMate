namespace BLL.DTOs
{
    public class CharacteristicDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Type { get; set; }
        public ICollection<WorkplaceCharacteristicsDTO> workplaceCharacteristicsDTOs { get; set; }
    }
}