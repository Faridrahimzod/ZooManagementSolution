using Microsoft.AspNetCore.Mvc;
using ZooManagement.Application.Services;

namespace ZooManagement.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatsController : ControllerBase
{
    private readonly ZooStatisticsService _stats;

    public StatsController(ZooStatisticsService stats) => _stats = stats;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _stats.GetStatisticsAsync());
}
