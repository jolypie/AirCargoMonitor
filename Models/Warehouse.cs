using System.ComponentModel.DataAnnotations;

namespace CargosMonitor.Models;

public class Warehouse
{
    [Key]
    public int WarehouseId {get; set;}
    
    [Required]
    [MaxLength(5)]
    public string WarehouseCode { get; set; }   
    
    [Required]
    public string Location { get; set; }
    
}