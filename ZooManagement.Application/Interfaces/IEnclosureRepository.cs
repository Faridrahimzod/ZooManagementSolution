using ZooManagement.Domain.Entities;

namespace ZooManagement.Application.Interfaces;

public interface IEnclosureRepository
{
    Task<IEnumerable<Enclosure>> GetAllAsync();
    Task<Enclosure?> GetByIdAsync(Guid id);
    Task AddAsync(Enclosure enclosure);
    Task UpdateAsync(Enclosure enclosure);
    Task RemoveAsync(Guid id);
}
