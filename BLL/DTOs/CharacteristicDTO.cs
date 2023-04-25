using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs
{
    public class CharacteristicDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "varchar(200)")]
		public string Type { get; set; }
        public ICollection<WorkspaceCharacteristicsDTO> WorkspaceCharacteristicsDtos { get; set; }
    }
}