using System.ComponentModel.DataAnnotations;

namespace CarBackend.Core.Models
{
    public class TrafficRecords
    {
        [Key]
        public int Id { get; set; }
        public string camera_Id { get; set; } = string.Empty;
        public int car_count { get; set; }
        public string car_type { get; set; } = string.Empty;
        public int Motorcycle_count { get; set; }
        public int Truck_count { get; set; }
        public int Bus_count { get; set; }
        public int Total_vehicles { get; set; }

    }
}
