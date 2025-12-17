using CarBackend.Core.Interfaces.IRepository;
using CarBackend.Core.Models.DTOs;
using CarBackend.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBackend.Data.Repositories
{
    public class TrafficRecordsRepository : ITrafficRecordsRepository
    {
        private readonly ApplicationDbContext _context;

        public TrafficRecordsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLogAsync(VehicleLog log)
        {
            await _context.vehicleLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task<CounterStatsDto> GetCountStatePerDay()
        {
            return new CounterStatsDto
            {
                CarCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Car" && v.DetectedAt >= DateTime.UtcNow.AddDays(-1)),
                BusCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Bus" && v.DetectedAt >= DateTime.UtcNow.AddDays(-1)),
                MotorcycleCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Motorcycle" && v.DetectedAt >= DateTime.UtcNow.AddDays(-1)),
                TruckCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Truck" && v.DetectedAt >= DateTime.UtcNow.AddDays(-1))
            };
        }

        public async Task<CounterStatsDto> GetCountStatePerMonth()
        {
            return new CounterStatsDto
            {

                CarCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Car" && v.DetectedAt >= DateTime.UtcNow.AddDays(-30)),
                BusCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Bus" && v.DetectedAt >= DateTime.UtcNow.AddDays(-30)),
                MotorcycleCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Motorcycle" && v.DetectedAt >= DateTime.UtcNow.AddDays(-30)),
                TruckCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Truck" && v.DetectedAt >= DateTime.UtcNow.AddDays(-30))
            };
        }

        public async Task<CounterStatsDto> GetCountStatePerWeek()
        {
            return new CounterStatsDto
            {
                CarCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Car" && v.DetectedAt >= DateTime.UtcNow.AddDays(-7)),
                BusCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Bus" && v.DetectedAt >= DateTime.UtcNow.AddDays(-7)),
                MotorcycleCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Motorcycle" && v.DetectedAt >= DateTime.UtcNow.AddDays(-7)),
                TruckCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Truck" && v.DetectedAt >= DateTime.UtcNow.AddDays(-7))
            };
        }

        public async Task<CounterStatsDto> GetCurrentStatsAsync()
        {
            return new CounterStatsDto
            {
                CarCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Car"),
                BusCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Bus"),
                MotorcycleCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Motorcycle"),
                TruckCount = await _context.vehicleLogs.CountAsync(v => v.VehicleType == "Truck")

            };
        }
    }

}
