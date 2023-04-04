﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DeskMateContext))]
    partial class DeskMateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BLL.DTOS.CharacteristicDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("characteristic");
                });

            modelBuilder.Entity("BLL.DTOS.CompanyDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("company");
                });

            modelBuilder.Entity("BLL.DTOS.FloorDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("floor");
                });

            modelBuilder.Entity("BLL.DTOS.LocationDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Postal")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("location");
                });

            modelBuilder.Entity("BLL.DTOS.PermissionDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("permission");
                });

            modelBuilder.Entity("BLL.DTOS.ReservationDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WorkspaceId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("reservation");
                });

            modelBuilder.Entity("BLL.DTOS.RoleDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("BLL.DTOS.RoomDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FloorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.ToTable("room");
                });

            modelBuilder.Entity("BLL.DTOS.UserDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("BLL.DTOS.WorkplaceCharacteristicsDTO", b =>
                {
                    b.Property<Guid>("WorkspaceId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CharacteristicId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("WorkspaceId", "CharacteristicId");

                    b.HasIndex("CharacteristicId");

                    b.ToTable("workplaceCharacteristic");
                });

            modelBuilder.Entity("BLL.DTOS.WorkplaceDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("workspace");
                });

            modelBuilder.Entity("BLL.DTOS.FloorDTO", b =>
                {
                    b.HasOne("BLL.DTOS.LocationDTO", "locationDTO")
                        .WithMany("floorDTO")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("locationDTO");
                });

            modelBuilder.Entity("BLL.DTOS.LocationDTO", b =>
                {
                    b.HasOne("BLL.DTOS.CompanyDTO", "companyDTO")
                        .WithMany("locationDTOList")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("companyDTO");
                });

            modelBuilder.Entity("BLL.DTOS.PermissionDTO", b =>
                {
                    b.HasOne("BLL.DTOS.RoleDTO", "roleDTO")
                        .WithMany("permissionDTO")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roleDTO");
                });

            modelBuilder.Entity("BLL.DTOS.ReservationDTO", b =>
                {
                    b.HasOne("BLL.DTOS.UserDTO", "userDTO")
                        .WithMany("reservationDTOs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BLL.DTOS.WorkplaceDTO", "workplaceDTO")
                        .WithMany("reservationDTOs")
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userDTO");

                    b.Navigation("workplaceDTO");
                });

            modelBuilder.Entity("BLL.DTOS.RoomDTO", b =>
                {
                    b.HasOne("BLL.DTOS.FloorDTO", "floorDTO")
                        .WithMany("roomDTO")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("floorDTO");
                });

            modelBuilder.Entity("BLL.DTOS.UserDTO", b =>
                {
                    b.HasOne("BLL.DTOS.CompanyDTO", "companyDTO")
                        .WithMany("userDTO")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BLL.DTOS.RoleDTO", "roleDTO")
                        .WithMany("userDTO")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("companyDTO");

                    b.Navigation("roleDTO");
                });

            modelBuilder.Entity("BLL.DTOS.WorkplaceCharacteristicsDTO", b =>
                {
                    b.HasOne("BLL.DTOS.CharacteristicDTO", "characteristicDTO")
                        .WithMany("workplaceCharacteristicsDTOs")
                        .HasForeignKey("CharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BLL.DTOS.WorkplaceDTO", "workplaceDTO")
                        .WithMany("workplaceCharacteristicsDTOs")
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("characteristicDTO");

                    b.Navigation("workplaceDTO");
                });

            modelBuilder.Entity("BLL.DTOS.WorkplaceDTO", b =>
                {
                    b.HasOne("BLL.DTOS.RoomDTO", "roomDTO")
                        .WithMany("workplaceDTO")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roomDTO");
                });

            modelBuilder.Entity("BLL.DTOS.CharacteristicDTO", b =>
                {
                    b.Navigation("workplaceCharacteristicsDTOs");
                });

            modelBuilder.Entity("BLL.DTOS.CompanyDTO", b =>
                {
                    b.Navigation("locationDTOList");

                    b.Navigation("userDTO");
                });

            modelBuilder.Entity("BLL.DTOS.FloorDTO", b =>
                {
                    b.Navigation("roomDTO");
                });

            modelBuilder.Entity("BLL.DTOS.LocationDTO", b =>
                {
                    b.Navigation("floorDTO");
                });

            modelBuilder.Entity("BLL.DTOS.RoleDTO", b =>
                {
                    b.Navigation("permissionDTO");

                    b.Navigation("userDTO");
                });

            modelBuilder.Entity("BLL.DTOS.RoomDTO", b =>
                {
                    b.Navigation("workplaceDTO");
                });

            modelBuilder.Entity("BLL.DTOS.UserDTO", b =>
                {
                    b.Navigation("reservationDTOs");
                });

            modelBuilder.Entity("BLL.DTOS.WorkplaceDTO", b =>
                {
                    b.Navigation("reservationDTOs");

                    b.Navigation("workplaceCharacteristicsDTOs");
                });
#pragma warning restore 612, 618
        }
    }
}
