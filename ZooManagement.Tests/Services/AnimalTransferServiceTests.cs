using System.Threading.Tasks;
using ZooManagement.Domain.Entities;
using ZooManagement.Application.Services;
using ZooManagement.Infrastructure.Persistence;
using Xunit;

namespace ZooManagement.Tests.Services;

public class AnimalTransferServiceTests
{
    [Fact]
    public async Task TransferAsync_MovesAnimalBetweenEnclosures()
    {
        // Arrange
        var animalRepo = new InMemoryAnimalRepository();
        var enclosureRepo = new InMemoryEnclosureRepository();

        var animal = new Animal("Lion", "Simba", DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-3)), Sex.Male, "Meat");
        await animalRepo.AddAsync(animal);

        var fromEnclosure = new Enclosure(EnclosureType.Predator, size: 100, maxCapacity: 10);
        var toEnclosure = new Enclosure(EnclosureType.Predator, size: 150, maxCapacity: 10);

        fromEnclosure.AddAnimal(animal.Id);
        animal.MoveTo(fromEnclosure.Id);

        await enclosureRepo.AddAsync(fromEnclosure);
        await enclosureRepo.AddAsync(toEnclosure);
        await animalRepo.UpdateAsync(animal);

        var svc = new AnimalTransferService(animalRepo, enclosureRepo);

        // Act
        await svc.TransferAsync(animal.Id, toEnclosure.Id);

        // Assert
        var updatedAnimal = await animalRepo.GetByIdAsync(animal.Id);
        Assert.Equal(toEnclosure.Id, updatedAnimal!.EnclosureId);

        var fromAfter = await enclosureRepo.GetByIdAsync(fromEnclosure.Id);
        var toAfter = await enclosureRepo.GetByIdAsync(toEnclosure.Id);

        Assert.DoesNotContain(animal.Id, fromAfter!.AnimalIds);
        Assert.Contains(animal.Id, toAfter!.AnimalIds);
    }
}
