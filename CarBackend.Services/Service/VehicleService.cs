using CarBackend.Core.Interfaces.INotificationService;
using CarBackend.Core.Interfaces.IRepository;
using CarBackend.Core.Interfaces.IService;
using CarBackend.Core.Models;
using CarBackend.Core.Models.DTOs;

namespace SmartParking.Services;

public class VehicleService : IVehicleService
{
    private readonly ITrafficRecordsRepository _repository;
    private readonly INotificationService _notificationService;

    public VehicleService(ITrafficRecordsRepository repository, INotificationService notificationService)
    {
        _repository = repository;
        this._notificationService = notificationService;
    }

    // POST
    public async Task ProcessVehicleEntryAsync(VehicleType type)
    {
        // save in the database 
        var log = new VehicleLog
        {
            VehicleType = type.ToString(),
            DetectedAt = DateTime.UtcNow
        };

        await _repository.AddLogAsync(log);

        // git new stats from the database 
        var newStats = await _repository.GetCurrentStatsAsync();

        // send it to the front end 
        await _notificationService.NotifyStatsUpdateAsync(newStats);
    }

    // GET
    public async Task<CounterStatsDto> GetCurrentStatsAsync()
    {
        //  GET
        return await _repository.GetCurrentStatsAsync();
    }

    public async Task<CounterStatsDto> GetCountStatePerDay()
    {
        return await _repository.GetCountStatePerDay();
    }

    // GET
    public async Task<CounterStatsDto> GetCountStatePerWeek()
    {
        return await _repository.GetCountStatePerWeek();
    }

    // GET
    public async Task<CounterStatsDto> GetCountStatePerMonth()
    {
        return await _repository.GetCountStatePerMonth();
    }
}