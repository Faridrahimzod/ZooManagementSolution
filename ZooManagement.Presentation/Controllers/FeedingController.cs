using Microsoft.AspNetCore.Mvc;
using ZooManagement.Application.Interfaces;
using ZooManagement.Application.Services;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedingController : ControllerBase
{
    private readonly FeedingOrganizationService _feedingService;

    public FeedingController(FeedingOrganizationService feedingService) => _feedingService = feedingService;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _feedingService.GetScheduleAsync());

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FeedingDto dto)
    {
        await _feedingService.ScheduleFeedingAsync(dto.AnimalId, dto.Time, dto.FoodType);
        return Ok();
    }
}

public record FeedingDto(Guid AnimalId, TimeOnly Time, string FoodType);
