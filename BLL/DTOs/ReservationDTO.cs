namespace BLL.DTOs
{
    public class ReservationDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public Guid WorkspaceId { get; set; }

        public UserDTO userDTO { get; set; }
        public WorkspaceDTO WorkspaceDto { get; set; }
    }
}