using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Infrastructure.Persistence;

public class InMemoryAnimalRepository : IAnimalRepository
{
    private readonly Dictionary<Guid, Animal> _animals = new();

    public Task AddAsync(Animal animal)
    {
        _animals[animal.Id] = animal;
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Animal>> GetAllAsync() => Task.FromResult(_animals.Values.AsEnumerable());

    public Task<Animal?> GetByIdAsync(Guid id) => Task.FromResult(_animals.TryGetValue(id, out var animal) ? animal : null);

    public Task RemoveAsync(Guid id)
    {
        _animals.Remove(id);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Animal animal)
    {
        _animals[animal.Id] = animal;
        return Task.CompletedTask;
    }
}
