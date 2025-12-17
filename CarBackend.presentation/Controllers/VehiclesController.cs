using CarBackend.Core.Interfaces.IService;
using CarBackend.Core.Models.DTOs;
using CarBackend.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBackend.Presentation.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehiclesController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    // POST api/vehicles/log
    [HttpPost("log")]
    public async Task<IActionResult> LogVehicle([FromBody] VehicleInputDto input)
    {
        if (input == null)
            return BadRequest("Invalid data");

        await _vehicleService.ProcessVehicleEntryAsync(input.VehicleType);

        return Ok(new { Message = "Vehicle processed successfully" });
    }

    // GET api/vehicles/stats
    [HttpGet("stats")]
    public async Task<ActionResult<CounterStatsDto>> GetCurrentStats()
    {
        var stats = await _vehicleService.GetCurrentStatsAsync();
        return Ok(stats);
    }

    // GET api/vehicles/stats/daily
    [HttpGet("stats/daily")]
    public async Task<ActionResult<CounterStatsDto>> GetDailyStats()
    {
        var stats = await _vehicleService.GetCountStatePerDay();
        return Ok(stats);
    }


    // GET api/vehicles/stats/weekly
    [HttpGet("stats/weekly")]
    public async Task<ActionResult<CounterStatsDto>> GetWeeklyStats()
    {
        var stats = await _vehicleService.GetCountStatePerWeek();
        return Ok(stats);
    }

    // GET api/vehicles/stats/monthly
    [HttpGet("stats/monthly")]
    public async Task<ActionResult<CounterStatsDto>> GetMonthlyStats()
    {
        var stats = await _vehicleService.GetCountStatePerMonth();
        return Ok(stats);
    }
}