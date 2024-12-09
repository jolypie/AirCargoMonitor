using CargosMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace CargosMonitor.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relation
        modelBuilder.Entity<Cargo>()
            .HasOne(c => c.Warehouse)
            .WithMany()
            .HasForeignKey(c => c.WarehouseId)
            .OnDelete(DeleteBehavior.SetNull); // If warehouse was deleted, cargo will stay, but without link to warehouse

        modelBuilder.Entity<Cargo>()
            .HasOne(c => c.Airplane)
            .WithMany(a => a.Cargos)
            .HasForeignKey(c => c.AirplaneId)
            .OnDelete(DeleteBehavior.SetNull); // If airplane was deleted, cargo will stay, but without link to airplane

        modelBuilder.Entity<Airplane>()
            .HasOne(a => a.Warehouse)
            .WithMany()
            .HasForeignKey(a => a.WarehouseId)
            .OnDelete(DeleteBehavior.SetNull); // If warehouse was deleted, airplane will stay, but without link to warehouse
        
        
        // Test data
        
        //Warehouse
        modelBuilder.Entity<Warehouse>().HasData(
            new Warehouse
            {
                WarehouseId = 1,
                WarehouseCode = "W101",
                Location = "New York"
            }
        );
        
        //Airplanes
        modelBuilder.Entity<Airplane>().HasData(
            new Airplane
            {
                AirplaneId = 1,
                AirplaneCode = "A101",
                MaxLoad = 50000,
                CurrentLoad = 0,
                WarehouseId = 1
            },
            new Airplane
            {
                AirplaneId = 2,
                AirplaneCode = "A102",
                MaxLoad = 60000,
                CurrentLoad = 0,
                WarehouseId = 1
            },
            new Airplane
            {
                AirplaneId = 3,
                AirplaneCode = "A103",
                MaxLoad = 45000,
                CurrentLoad = 0,
                WarehouseId = 1
            }
        );
        
        // Cargos
        modelBuilder.Entity<Cargo>().HasData(
            new Cargo { CargoId = 1, CargoCode = "C101", Weight = 500, Status = CargoStatus.InWarehouse, WarehouseId = 1 },
            new Cargo { CargoId = 2, CargoCode = "C102", Weight = 300, Status = CargoStatus.InWarehouse, WarehouseId = 1 },
            new Cargo { CargoId = 3, CargoCode = "C103", Weight = 1000, Status = CargoStatus.Pending },
            new Cargo { CargoId = 4, CargoCode = "C104", Weight = 200, Status = CargoStatus.InPlane, AirplaneId = 1 },
            new Cargo { CargoId = 5, CargoCode = "C105", Weight = 800, Status = CargoStatus.InPlane, AirplaneId = 2 },
            new Cargo { CargoId = 6, CargoCode = "C106", Weight = 1500, Status = CargoStatus.Pending },
            new Cargo { CargoId = 7, CargoCode = "C107", Weight = 700, Status = CargoStatus.InWarehouse, WarehouseId = 1 },
            new Cargo { CargoId = 8, CargoCode = "C108", Weight = 1200, Status = CargoStatus.Pending },
            new Cargo { CargoId = 9, CargoCode = "C109", Weight = 400, Status = CargoStatus.InPlane, AirplaneId = 3 },
            new Cargo { CargoId = 10, CargoCode = "C110", Weight = 600, Status = CargoStatus.InWarehouse, WarehouseId = 1 }
        );
    }

    public DbSet<Airplane> Airplanes { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
}