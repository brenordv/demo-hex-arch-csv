using System.Transactions;
using FluentAssertions;
using HexArch.Csv.Domain.Entities;
using HexArch.Csv.Domain.Exceptions;
using HexArch.Csv.Domain.Interfaces.Repositories;
using HexArch.Csv.Domain.Interfaces.Services;
using HexArch.Csv.Domain.Services.Services;
using Moq;

namespace HexArch.Csv.Domain.Services.Test.Services;

public class PeopleServiceTests
{
    private readonly Mock<IPeopleRepository> _peopleRepositoryMock;
    private readonly IPeopleService _sut;


    public PeopleServiceTests()
    {
        _peopleRepositoryMock = new Mock<IPeopleRepository>();
        _peopleRepositoryMock.Setup(r => r.BeginTransaction()).Returns(new TransactionScope());
        _sut = new PeopleService(_peopleRepositoryMock.Object);
    }

    [Fact]
    public void Add_WhenCalledWithValidInput_ShouldAddPeopleToRepository()
    {
        // Arrange
        var people = new List<Person>
        {
            new() { Name = "Alice", BirthDate = new DateTime(1990, 1, 1) },
            new() { Name = "Bob", BirthDate = new DateTime(1995, 2, 2) },
        };

        // Act
        var result = _sut.Add(people);

        // Assert
        result.Should().Be(2);
        _peopleRepositoryMock.Verify(r => r.BeginTransaction(), Times.Once);
        _peopleRepositoryMock.Verify(r => r.Add(It.IsAny<Person>()), Times.Exactly(2));
    }

    [Fact]
    public void Add_WhenCalledWithNullInput_ShouldThrowArgumentNullException()
    {
        // Arrange
        // Act
        var act = () => _sut.Add(null);

        // Assert
        act.Should().Throw<HexValidationException>();
        _peopleRepositoryMock.Verify(r => r.BeginTransaction(), Times.Never);
        _peopleRepositoryMock.Verify(r => r.Add(It.IsAny<Person>()), Times.Never);
    }

    [Fact]
    public void Add_WhenAddThrowsException_ShouldThrowHexServiceException()
    {
        // Arrange
        var people = new List<Person>
        {
            new() { Id = 1, Name = "Alice", BirthDate = new DateTime(1990, 1, 1) },
            new() { Id = 2, Name = "Bob", BirthDate = new DateTime(1995, 2, 2) },
            new() { Id = 3, Name = "Charlie", BirthDate = new DateTime(2000, 3, 3) },
        };

        _peopleRepositoryMock.Setup(r => r.Add(It.IsAny<Person>()))
            .Callback<Person>(p =>
            {
                if (p.Id == 2)
                {
                    throw new Exception("Simulated error");
                }
            });

        // Act
        var act = () => _sut.Add(people);

        // Assert
        act.Should().Throw<HexServiceException>()
            .WithMessage("Failed to add person #2: Person { Id = 2, Name = Bob, BirthDate = 02/02/1995 00:00:00 }");
        _peopleRepositoryMock.Verify(r => r.BeginTransaction(), Times.Once);
        _peopleRepositoryMock.Verify(r => r.Add(It.IsAny<Person>()), Times.Exactly(2));
    }
}