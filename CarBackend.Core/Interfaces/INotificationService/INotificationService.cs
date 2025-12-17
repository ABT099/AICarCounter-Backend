using CarBackend.Core.Models.DTOs;

namespace CarBackend.Core.Interfaces.INotificationService
{
    public interface INotificationService
    {

        Task NotifyStatsUpdateAsync(CounterStatsDto newStats);
    }
}