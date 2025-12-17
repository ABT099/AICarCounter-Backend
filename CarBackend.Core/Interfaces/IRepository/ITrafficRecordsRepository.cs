using CarBackend.Core.Models.DTOs;

namespace CarBackend.Core.Interfaces.IRepository
{
    public interface ITrafficRecordsRepository
    {
        public Task AddLogAsync(VehicleLog log);
        public Task<CounterStatsDto> GetCurrentStatsAsync();
        public Task<CounterStatsDto> GetCountStatePerDay();
        public Task<CounterStatsDto> GetCountStatePerWeek();
        public Task<CounterStatsDto> GetCountStatePerMonth();

    }
}
