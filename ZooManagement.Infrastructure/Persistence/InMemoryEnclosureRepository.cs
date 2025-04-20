using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Infrastructure.Persistence;

public class InMemoryEnclosureRepository : IEnclosureRepository
{
    private readonly Dictionary<Guid, Enclosure> _enclosures = new();

    public Task AddAsync(Enclosure enclosure)
    {
        _enclosures[enclosure.Id] = enclosure;
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Enclosure>> GetAllAsync() => Task.FromResult(_enclosures.Values.AsEnumerable());

    public Task<Enclosure?> GetByIdAsync(Guid id) => Task.FromResult(_enclosures.TryGetValue(id, out var e) ? e : null);

    public Task RemoveAsync(Guid id)
    {
        _enclosures.Remove(id);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Enclosure enclosure)
    {
        _enclosures[enclosure.Id] = enclosure;
        return Task.CompletedTask;
    }
}
