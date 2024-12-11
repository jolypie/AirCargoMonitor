using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargosMonitor.Models;

public class Airplane
{
    [Key]
    public int AirplaneId { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string AirplaneCode { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal MaxLoad { get; set; } 

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal CurrentLoad { get; set; } 
    
    [Required]
    [ForeignKey("Warehouse")]
    public int WarehouseId { get; set; } 
    public Warehouse Warehouse { get; set; }
}