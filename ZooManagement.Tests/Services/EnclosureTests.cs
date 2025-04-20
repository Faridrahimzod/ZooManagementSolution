using System;
using ZooManagement.Domain.Entities;
using Xunit;

namespace ZooManagement.Tests.Services;

public class EnclosureTests
{
    [Fact]
    public void AddAnimal_Throws_WhenMaxCapacityReached()
    {
        var enclosure = new Enclosure(EnclosureType.Bird, size: 30, maxCapacity: 1);

        var first = Guid.NewGuid();
        var second = Guid.NewGuid();

        enclosure.AddAnimal(first);

        Assert.Throws<InvalidOperationException>(() => enclosure.AddAnimal(second));
    }
}
