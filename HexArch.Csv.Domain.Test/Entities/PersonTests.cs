using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using HexArch.Csv.Domain.Entities;

namespace HexArch.Csv.Domain.Test.Entities;

public class PersonTests
{
    [Fact]
    public void Id_ShouldThrowValidationException_WhenSetToZero()
    {
        // Arrange
        var person = new Person();

        // Act
        var act = () => person with { Id = 0 };

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Value 0 is not greater than 0.");
    }

    [Fact]
    public void Name_ShouldThrowValidationException_WhenSetToLongerThan50Characters()
    {
        // Arrange
        var person = new Person();
        var longName = new string('x', 51);

        // Act
        var act = () => person with { Name = longName };

        // Assert
        act.Should().Throw<ValidationException>().WithMessage($"Text {longName} is longer than 50 characters.");
    }

    [Fact]
    public void BirthDate_ShouldThrowValidationException_WhenSetToFutureDate()
    {
        // Arrange
        var person = new Person();
        var futureDate = DateTime.Now.AddDays(1);

        // Act
        var act = () => person with { BirthDate = futureDate };

        // Assert
        act.Should().Throw<ValidationException>().WithMessage($"Date {futureDate} is not in the past.");
    }

    [Fact]
    public void BirthDate_ShouldThrowValidationException_WhenSetToBeforeSqlServerMinDate()
    {
        // Arrange
        var person = new Person();
        var beforeSqlServerMinDate = new DateTime(1752, 12, 31);

        // Act
        var act = () => person with { BirthDate = beforeSqlServerMinDate };

        // Assert
        act.Should().Throw<ValidationException>()
            .WithMessage($"Date {beforeSqlServerMinDate} is before the minimum date for SQL Server.");
    }

    [Fact]
    public void BirthDate_ShouldThrowValidationException_WhenSetToMaxValue()
    {
        // Arrange
        var person = new Person();
        var maxDate = DateTime.MaxValue;

        // Act
        var act = () => person with { BirthDate = maxDate };

        // Assert
        act.Should().Throw<ValidationException>().WithMessage($"Date {maxDate} is the maximum date.");
    }
}