namespace ZooManagement.Domain.Entities;

public enum EnclosureType { Predator, Herbivore, Bird, Aquarium, Other }

public class Enclosure
{
    private readonly List<Guid> _animalIds = new();

    public Guid Id { get; } = Guid.NewGuid();
    public EnclosureType Type { get; private set; }
    public int Size { get; private set; }
    public int MaxCapacity { get; private set; }

    public IReadOnlyCollection<Guid> AnimalIds => _animalIds.AsReadOnly();

    public Enclosure(EnclosureType type, int size, int maxCapacity)
    {
        Type = type;
        Size = size;
        MaxCapacity = maxCapacity;
    }

    public bool CanAddAnimal() => _animalIds.Count < MaxCapacity;

    public void AddAnimal(Guid animalId)
    {
        if (!CanAddAnimal())
            throw new InvalidOperationException("Enclosure is full.");
        _animalIds.Add(animalId);
    }

    public void RemoveAnimal(Guid animalId) => _animalIds.Remove(animalId);
}
