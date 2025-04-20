using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Application.Services;

public class AnimalTransferService
{
    private readonly IAnimalRepository _animals;
    private readonly IEnclosureRepository _enclosures;

    public AnimalTransferService(IAnimalRepository animals, IEnclosureRepository enclosures)
    {
        _animals = animals;
        _enclosures = enclosures;
    }

    public async Task TransferAsync(Guid animalId, Guid toEnclosureId)
    {
        var animal = await _animals.GetByIdAsync(animalId) ?? throw new InvalidOperationException("Animal not found");
        var toEnclosure = await _enclosures.GetByIdAsync(toEnclosureId) ?? throw new InvalidOperationException("Enclosure not found");

        if (!toEnclosure.CanAddAnimal())
            throw new InvalidOperationException("Destination enclosure is full");

        Guid? fromId = animal.EnclosureId;

        if (fromId.HasValue)
        {
            var currentEnclosure = await _enclosures.GetByIdAsync(fromId.Value);
            currentEnclosure?.RemoveAnimal(animal.Id);
            await _enclosures.UpdateAsync(currentEnclosure!);
        }

        toEnclosure.AddAnimal(animal.Id);
        await _enclosures.UpdateAsync(toEnclosure);

        animal.MoveTo(toEnclosure.Id);
        await _animals.UpdateAsync(animal);
    }
}
