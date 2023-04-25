using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs
{
    public class RoomDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "varchar(200)")] public string Name { get; set; }
        public Guid FloorId { get; set; }
        public FloorDTO floorDTO { get; set; }
        public ICollection<WorkspaceDTO> WorkspaceDtos { get; set; }
    }
}