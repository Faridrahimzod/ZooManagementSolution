using ZooManagement.Domain.Entities;

namespace ZooManagement.Application.Interfaces;

public interface IAnimalRepository
{
    Task<IEnumerable<Animal>> GetAllAsync();
    Task<Animal?> GetByIdAsync(Guid id);
    Task AddAsync(Animal animal);
    Task UpdateAsync(Animal animal);
    Task RemoveAsync(Guid id);
}
