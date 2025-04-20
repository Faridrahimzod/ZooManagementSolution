namespace ZooManagement.Domain.Entities;

public enum Sex { Male, Female }
public enum AnimalStatus { Healthy, Sick }

public class Animal
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Species { get; private set; }
    public string Name { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public Sex Sex { get; private set; }
    public string FavoriteFood { get; private set; }
    public AnimalStatus Status { get; private set; } = AnimalStatus.Healthy;
    public Guid? EnclosureId { get; private set; }

    public Animal(string species, string name, DateOnly birthDate, Sex sex, string favoriteFood)
    {
        Species = species;
        Name = name;
        BirthDate = birthDate;
        Sex = sex;
        FavoriteFood = favoriteFood;
    }

    public void Feed() => Status = AnimalStatus.Healthy;

    public void Treat() => Status = AnimalStatus.Healthy;

    public void MoveTo(Guid enclosureId)
    {
        EnclosureId = enclosureId;
        // domain event could be published here
    }
}
