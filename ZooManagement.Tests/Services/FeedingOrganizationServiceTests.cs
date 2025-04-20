using System.Threading.Tasks;
using ZooManagement.Domain.Entities;
using ZooManagement.Application.Services;
using ZooManagement.Infrastructure.Persistence;
using Xunit;

namespace ZooManagement.Tests.Services;

public class FeedingOrganizationServiceTests
{
    [Fact]
    public async Task ScheduleFeedingAsync_AddsSchedule()
    {
        var animalRepo = new InMemoryAnimalRepository();
        var scheduleRepo = new InMemoryFeedingScheduleRepository();

        var animal = new Animal("Giraffe", "Melman", DateOnly.Parse("2019-05-01"), Sex.Male, "Leaves");
        await animalRepo.AddAsync(animal);

        var svc = new FeedingOrganizationService(scheduleRepo, animalRepo);

        await svc.ScheduleFeedingAsync(animal.Id, new TimeOnly(10, 0), "Leaves");

        var schedules = await scheduleRepo.GetForAnimalAsync(animal.Id);
        Assert.Single(schedules);
    }
}
