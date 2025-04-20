namespace ZooManagement.Domain.Entities;

public class FeedingSchedule
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid AnimalId { get; private set; }
    public TimeOnly FeedingTime { get; private set; }
    public string FoodType { get; private set; }

    public FeedingSchedule(Guid animalId, TimeOnly feedingTime, string foodType)
    {
        AnimalId = animalId;
        FeedingTime = feedingTime;
        FoodType = foodType;
    }

    public void Reschedule(TimeOnly newTime) => FeedingTime = newTime;
}
