using ZooManagement.Application.Interfaces;
using ZooManagement.Domain.Entities;

namespace ZooManagement.Application.Services;

public class FeedingOrganizationService
{
    private readonly IFeedingScheduleRepository _schedules;
    private readonly IAnimalRepository _animals;

    public FeedingOrganizationService(IFeedingScheduleRepository schedules, IAnimalRepository animals)
    {
        _schedules = schedules;
        _animals = animals;
    }

    public async Task ScheduleFeedingAsync(Guid animalId, TimeOnly time, string foodType)
    {
        var animal = await _animals.GetByIdAsync(animalId) ?? throw new InvalidOperationException("Animal not found");
        var schedule = new FeedingSchedule(animal.Id, time, foodType);
        await _schedules.AddAsync(schedule);
    }

    public async Task<IEnumerable<FeedingSchedule>> GetScheduleAsync() => await _schedules.GetAllAsync();
}
