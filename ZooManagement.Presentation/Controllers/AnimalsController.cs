using Microsoft.AspNetCore.Mvc;
using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalRepository _animals;

    public AnimalsController(IAnimalRepository animals) => _animals = animals;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _animals.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var animal = await _animals.GetByIdAsync(id);
        return animal is null ? NotFound() : Ok(animal);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AnimalDto dto)
    {
        var animal = new Animal(dto.Species, dto.Name, dto.BirthDate, dto.Sex, dto.FavoriteFood);
        await _animals.AddAsync(animal);
        return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _animals.RemoveAsync(id);
        return NoContent();
    }
}

public record AnimalDto(string Species, string Name, DateOnly BirthDate, Sex Sex, string FavoriteFood);
