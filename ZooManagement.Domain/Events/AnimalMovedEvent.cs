namespace ZooManagement.Domain.Events;

public record AnimalMovedEvent(Guid AnimalId, Guid FromEnclosureId, Guid ToEnclosureId, DateTimeOffset At);
