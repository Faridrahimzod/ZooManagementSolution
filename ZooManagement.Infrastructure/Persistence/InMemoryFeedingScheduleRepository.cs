using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Infrastructure.Persistence;

public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
{
    private readonly Dictionary<Guid, FeedingSchedule> _schedules = new();

    public Task AddAsync(FeedingSchedule schedule)
    {
        _schedules[schedule.Id] = schedule;
        return Task.CompletedTask;
    }

    public Task<IEnumerable<FeedingSchedule>> GetAllAsync() => Task.FromResult(_schedules.Values.AsEnumerable());

    public Task<IEnumerable<FeedingSchedule>> GetForAnimalAsync(Guid animalId) => 
        Task.FromResult(_schedules.Values.Where(s => s.AnimalId == animalId).AsEnumerable());

    public Task RemoveAsync(Guid id)
    {
        _schedules.Remove(id);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(FeedingSchedule schedule)
    {
        _schedules[schedule.Id] = schedule;
        return Task.CompletedTask;
    }
}
