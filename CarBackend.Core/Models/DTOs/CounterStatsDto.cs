namespace CarBackend.Core.Models.DTOs
{
    public class CounterStatsDto
    {
        public int CarCount { get; set; }
        public int BusCount { get; set; }
        public int MotorcycleCount { get; set; }
        public int TruckCount { get; set; }
        public int TotalCount => CarCount + BusCount + MotorcycleCount + TruckCount;
    }
}
