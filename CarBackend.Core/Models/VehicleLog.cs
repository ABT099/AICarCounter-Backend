using System.ComponentModel.DataAnnotations;

public class VehicleLog
{
    [Key]
    public int Id { get; set; }
    public string VehicleType { get; set; }
    public DateTime DetectedAt { get; set; }
}