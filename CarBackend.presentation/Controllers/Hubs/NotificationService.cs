using CarBackend.Core.Interfaces.INotificationService;
using CarBackend.Core.Models.DTOs;
using CarBackend.Presentation.Controllers.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace CarBackend.Presentation.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<VehicleHub> _hubContext;

        public NotificationService(IHubContext<VehicleHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyStatsUpdateAsync(CounterStatsDto newStats)
        {
            // هنا نستخدم SignalR فعلياً
            await _hubContext.Clients.All.SendAsync("UpdateStats", newStats);
        }
    }
}