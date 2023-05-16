namespace BLL.DTOs
{
    public class CharacteristicDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        public ICollection<WorkspaceCharacteristicsDTO> workspaceCharacteristicsDTOs { get; set; }
    }
}