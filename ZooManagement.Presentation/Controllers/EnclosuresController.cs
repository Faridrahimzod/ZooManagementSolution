using Microsoft.AspNetCore.Mvc;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnclosuresController : ControllerBase
{
    private readonly IEnclosureRepository _enclosures;

    public EnclosuresController(IEnclosureRepository enclosures) => _enclosures = enclosures;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _enclosures.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EnclosureDto dto)
    {
        var enclosure = new Enclosure(dto.Type, dto.Size, dto.MaxCapacity);
        await _enclosures.AddAsync(enclosure);
        return CreatedAtAction(nameof(Get), new { id = enclosure.Id }, enclosure);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _enclosures.RemoveAsync(id);
        return NoContent();
    }
}

public record EnclosureDto(EnclosureType Type, int Size, int MaxCapacity);
