﻿// <auto-generated />
using CargosMonitor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CargosMonitor.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CargosMonitor.Models.Airplane", b =>
                {
                    b.Property<int>("AirplaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AirplaneId"));

                    b.Property<string>("AirplaneCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("CurrentLoad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaxLoad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("AirplaneId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Airplanes");

                    b.HasData(
                        new
                        {
                            AirplaneId = 1,
                            AirplaneCode = "A101",
                            CurrentLoad = 0m,
                            MaxLoad = 50000m,
                            WarehouseId = 1
                        },
                        new
                        {
                            AirplaneId = 2,
                            AirplaneCode = "A102",
                            CurrentLoad = 0m,
                            MaxLoad = 60000m,
                            WarehouseId = 1
                        },
                        new
                        {
                            AirplaneId = 3,
                            AirplaneCode = "A103",
                            CurrentLoad = 0m,
                            MaxLoad = 45000m,
                            WarehouseId = 1
                        });
                });

            modelBuilder.Entity("CargosMonitor.Models.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoId"));

                    b.Property<int?>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<string>("CargoCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CargoId");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Cargos");

                    b.HasData(
                        new
                        {
                            CargoId = 1,
                            CargoCode = "C101",
                            Status = 0,
                            WarehouseId = 1,
                            Weight = 500m
                        },
                        new
                        {
                            CargoId = 2,
                            CargoCode = "C102",
                            Status = 0,
                            WarehouseId = 1,
                            Weight = 300m
                        },
                        new
                        {
                            CargoId = 3,
                            CargoCode = "C103",
                            Status = 2,
                            Weight = 1000m
                        },
                        new
                        {
                            CargoId = 4,
                            AirplaneId = 1,
                            CargoCode = "C104",
                            Status = 1,
                            Weight = 200m
                        },
                        new
                        {
                            CargoId = 5,
                            AirplaneId = 2,
                            CargoCode = "C105",
                            Status = 1,
                            Weight = 800m
                        },
                        new
                        {
                            CargoId = 6,
                            CargoCode = "C106",
                            Status = 2,
                            Weight = 1500m
                        },
                        new
                        {
                            CargoId = 7,
                            CargoCode = "C107",
                            Status = 0,
                            WarehouseId = 1,
                            Weight = 700m
                        },
                        new
                        {
                            CargoId = 8,
                            CargoCode = "C108",
                            Status = 2,
                            Weight = 1200m
                        },
                        new
                        {
                            CargoId = 9,
                            AirplaneId = 3,
                            CargoCode = "C109",
                            Status = 1,
                            Weight = 400m
                        },
                        new
                        {
                            CargoId = 10,
                            CargoCode = "C110",
                            Status = 0,
                            WarehouseId = 1,
                            Weight = 600m
                        });
                });

            modelBuilder.Entity("CargosMonitor.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouses");

                    b.HasData(
                        new
                        {
                            WarehouseId = 1,
                            Location = "New York",
                            WarehouseCode = "W101"
                        });
                });

            modelBuilder.Entity("CargosMonitor.Models.Airplane", b =>
                {
                    b.HasOne("CargosMonitor.Models.Warehouse", "Warehouse")
                        .WithMany("Airplanes")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("CargosMonitor.Models.Cargo", b =>
                {
                    b.HasOne("CargosMonitor.Models.Airplane", "Airplane")
                        .WithMany("Cargos")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("CargosMonitor.Models.Warehouse", "Warehouse")
                        .WithMany("Cargos")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Airplane");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("CargosMonitor.Models.Airplane", b =>
                {
                    b.Navigation("Cargos");
                });

            modelBuilder.Entity("CargosMonitor.Models.Warehouse", b =>
                {
                    b.Navigation("Airplanes");

                    b.Navigation("Cargos");
                });
#pragma warning restore 612, 618
        }
    }
}