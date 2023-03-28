using BLL.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DeskMateContext: DbContext
    {
        public DbSet<LocationDTO> location { get; set; } 
        public DbSet<PermissionDTO> permission { get; set; }
        public DbSet<RoleDTO> role { get; set; }
        public DbSet<CompanyDTO> company { get; set; }
        public DbSet<CharacteristicDTO> characteristic { get; set; }
        public DbSet<FloorDTO> floor { get; set; }
        public DbSet<ReservationDTO> reservation { get; set; }
        public DbSet<WorkplaceDTO> workspace { get; set; }
        public DbSet<WorkplaceCharacteristicsDTO> workplaceCharacteristic { get; set; }
        public DbSet<RoomDTO> room { get; set; }
        public DbSet<UserDTO> user { get; set; }

        public DeskMateContext(DbContextOptions<DeskMateContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
           modelBuilder.Entity<WorkplaceCharacteristicsDTO>().HasKey(w => new { w.WorkspaceId, w.CharacteristicId });
           
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

           

        }
    }
}
