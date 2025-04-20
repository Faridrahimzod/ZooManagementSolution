using ZooManagement.Domain.Entities;

namespace ZooManagement.Application.Interfaces;

public interface IFeedingScheduleRepository
{
    Task<IEnumerable<FeedingSchedule>> GetAllAsync();
    Task<IEnumerable<FeedingSchedule>> GetForAnimalAsync(Guid animalId);
    Task AddAsync(FeedingSchedule schedule);
    Task UpdateAsync(FeedingSchedule schedule);
    Task RemoveAsync(Guid id);
}
