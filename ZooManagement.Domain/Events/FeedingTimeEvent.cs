namespace ZooManagement.Domain.Events;

public record FeedingTimeEvent(Guid AnimalId, DateTimeOffset FeedingTime);
