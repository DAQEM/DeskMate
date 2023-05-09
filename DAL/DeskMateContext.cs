using BLL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DeskMateContext : DbContext
    {
        public DbSet<LocationDTO> location { get; set; }
        public DbSet<PermissionDTO> permission { get; set; }
        public DbSet<RoleDTO> role { get; set; }
        public DbSet<CompanyDTO> company { get; set; }
        public DbSet<CharacteristicDTO> characteristic { get; set; }
        public DbSet<FloorDTO> floor { get; set; }
        public DbSet<ReservationDTO> reservation { get; set; }
        public DbSet<WorkspaceDTO> workspace { get; set; }
        public DbSet<WorkspaceCharacteristicsDTO> workspaceCharacteristic { get; set; }
        public DbSet<RoomDTO> room { get; set; }
        public DbSet<UserDTO> user { get; set; }

        public DeskMateContext(DbContextOptions<DeskMateContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkspaceCharacteristicsDTO>().HasKey(w => new { w.WorkspaceId, w.CharacteristicId });

            modelBuilder.Entity<CompanyDTO>()
                .HasMany(c => c.locationDTOList)
                .WithOne(l => l.companyDTO)
                .HasForeignKey(l => l.CompanyId);

            modelBuilder.Entity<RoleDTO>()
                .HasMany(r => r.permissionDTO)
                .WithOne(p => p.roleDTO)
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<FloorDTO>()
                .HasMany(f => f.roomDTO)
                .WithOne(r => r.floorDTO)
                .HasForeignKey(r => r.FloorId);

            modelBuilder.Entity<LocationDTO>()
                .HasMany(l => l.floorDTO)
                .WithOne(f => f.locationDTO)
                .HasForeignKey(f => f.LocationId);

            modelBuilder.Entity<RoomDTO>()
                .HasMany(r => r.workplaceDTO)
                .WithOne(w => w.roomDTO)
                .HasForeignKey(w => w.RoomId);


            modelBuilder.Entity<RoleDTO>()
                .HasMany(r => r.userDTO)
                .WithOne(u => u.roleDTO)
                .HasForeignKey(u => u.RoleId);


            modelBuilder.Entity<CompanyDTO>()
                .HasMany(c => c.userDTO)
                .WithOne(u => u.companyDTO)
                .HasForeignKey(u => u.CompanyId);


            modelBuilder.Entity<UserDTO>()
                .HasMany(u => u.reservationDTOs)
                .WithOne(r => r.userDTO)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<WorkspaceDTO>()
                .HasMany(w => w.reservationDTOs)
                .WithOne(r => r._WorkspaceDto)
                .HasForeignKey(r => r.WorkspaceId);

            modelBuilder.Entity<WorkspaceDTO>()
                .HasMany(w => w.workspaceCharacteristicsDTOs)
                .WithOne(wc => wc._WorkspaceDto)
                .HasForeignKey(wc => wc.WorkspaceId);

            modelBuilder.Entity<CharacteristicDTO>()
                .HasMany(c => c.WorkspaceCharacteristicsDtos)
                .WithOne(wc => wc.characteristicDTO)
                .HasForeignKey(wc => wc.CharacteristicId);
        }
    }
}