using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargosMonitor.Models;

public enum CargoStatus
{
    InWarehouse,
    InPlane
}

public class Cargo
{
    [Key]
    public int CargoId { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string CargoCode { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Weight { get; set; }
    
    [Required]
    public CargoStatus Status { get; set; }
    

    [ForeignKey("Airplane")] 
    public int? AirplaneId { get; set; }
    public Airplane? Airplane { get; set; }
    
    
    
    [ForeignKey("Warehouse")]
    public int? WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }
    
    public DateTime? AddedToWarehouseAt { get; set; }
    public DateTime? AddedToAirplaneAt { get; set; }
}