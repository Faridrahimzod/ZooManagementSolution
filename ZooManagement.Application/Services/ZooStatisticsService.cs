using ZooManagement.Application.Interfaces;

namespace ZooManagement.Application.Services;

public class ZooStatisticsService
{
    private readonly IAnimalRepository _animals;
    private readonly IEnclosureRepository _enclosures;

    public ZooStatisticsService(IAnimalRepository animals, IEnclosureRepository enclosures)
    {
        _animals = animals;
        _enclosures = enclosures;
    }

    public async Task<object> GetStatisticsAsync()
    {
        var animals = await _animals.GetAllAsync();
        var enclosures = await _enclosures.GetAllAsync();

        return new
        {
            TotalAnimals = animals.Count(),
            FreeEnclosures = enclosures.Count(e => !e.AnimalIds.Any()),
            TotalEnclosures = enclosures.Count()
        };
    }
}
