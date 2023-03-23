using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using HexArch.Csv.Domain.Validations;

namespace HexArch.Csv.Domain.Test.Validations;

public class ValidatorsTests
{
    [Fact]
    public void EnsureDateIsInPast_ThrowsException_WhenDateIsInTheFuture()
    {
        // Arrange
        var futureDate = DateTime.Now.AddDays(1);

        // Act
        var act = () => Validators.EnsureDateIsInPast(futureDate);

        // Assert
        act.Should().Throw<ValidationException>()
            .WithMessage($"Date {futureDate} is not in the past.");
    }

    [Fact]
    public void EnsureDateIsInPast_DoesNotThrowException_WhenDateIsInThePast()
    {
        // Arrange
        var pastDate = DateTime.Now.AddDays(-1);

        // Act
        var act = () => Validators.EnsureDateIsInPast(pastDate);

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void EnsureDateIsAfterSqlServerMin_ThrowsException_WhenDateIsBeforeSqlServerMin()
    {
        // Arrange
        var dateBeforeSqlServerMin = new DateTime(1752, 12, 31);

        // Act
        var act = () => Validators.EnsureDateIsAfterSqlServerMin(dateBeforeSqlServerMin);

        // Assert
        act.Should().Throw<ValidationException>()
            .WithMessage($"Date {dateBeforeSqlServerMin} is before the minimum date for SQL Server.");
    }

    [Fact]
    public void EnsureDateIsAfterSqlServerMin_DoesNotThrowException_WhenDateIsAfterSqlServerMin()
    {
        // Arrange
        var dateAfterSqlServerMin = new DateTime(1753, 1, 1);

        // Act
        var act = () => Validators.EnsureDateIsAfterSqlServerMin(dateAfterSqlServerMin);

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void EnsureDateIsNotMax_ThrowsException_WhenDateIsMaxValue()
    {
        // Arrange
        var maxDate = DateTime.MaxValue;

        // Act
        var act = () => Validators.EnsureDateIsNotMax(maxDate);

        // Assert
        act.Should().Throw<ValidationException>()
            .WithMessage($"Date {maxDate} is the maximum date.");
    }

    [Fact]
    public void EnsureDateIsNotMax_DoesNotThrowException_WhenDateIsNotMaxValue()
    {
        // Arrange
        var nonMaxDate = new DateTime(2022, 3, 21);

        // Act
        var act = () => Validators.EnsureDateIsNotMax(nonMaxDate);

        // Assert
        act.Should().NotThrow();
    }
}