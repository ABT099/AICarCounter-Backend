using CarBackend.Core.Models;
using CarBackend.Core.Models.DTOs;

namespace CarBackend.Core.Interfaces.IService
{
    public interface IVehicleService
    {
        Task ProcessVehicleEntryAsync(VehicleType type);
        Task<CounterStatsDto> GetCurrentStatsAsync();
        Task<CounterStatsDto> GetCountStatePerDay();
        Task<CounterStatsDto> GetCountStatePerWeek();
        Task<CounterStatsDto> GetCountStatePerMonth();
    }
}