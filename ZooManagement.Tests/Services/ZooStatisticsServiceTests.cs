using System.Threading.Tasks;
using ZooManagement.Domain.Entities;
using ZooManagement.Application.Services;
using ZooManagement.Infrastructure.Persistence;
using Xunit;

namespace ZooManagement.Tests.Services;

public class ZooStatisticsServiceTests
{
    [Fact]
    public async Task GetStatisticsAsync_ReturnsCorrectCounts()
    {
        var animalRepo = new InMemoryAnimalRepository();
        var enclosureRepo = new InMemoryEnclosureRepository();

        var enclosure = new Enclosure(EnclosureType.Herbivore, size: 120, maxCapacity: 5);
        await enclosureRepo.AddAsync(enclosure);

        var animal = new Animal("Zebra", "Marty", DateOnly.Parse("2020-02-14"), Sex.Male, "Grass");
        await animalRepo.AddAsync(animal);

        var statsSvc = new ZooStatisticsService(animalRepo, enclosureRepo);

        var stats = await statsSvc.GetStatisticsAsync();

        Assert.Equal(1, stats.GetType().GetProperty("TotalAnimals")!.GetValue(stats));
        Assert.Equal(0, stats.GetType().GetProperty("FreeEnclosures")!.GetValue(stats));
        Assert.Equal(1, stats.GetType().GetProperty("TotalEnclosures")!.GetValue(stats));
    }
}
