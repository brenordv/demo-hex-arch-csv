using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using HexArch.Csv.Domain.Validations;

namespace HexArch.Csv.Domain.Test.Validations;

public class NumericValidatorsTests
{
    [Theory]
    [InlineData(1, 0)]
    [InlineData(10, 5)]
    [InlineData(100, 50)]
    public void EnsureGreaterThan_DoesNotThrowException_WhenValueIsGreaterThanMin(int value, int min)
    {
        // Act
        var act = () => Validators.EnsureGreaterThan(value, min);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(-10, -5)]
    [InlineData(50, 100)]
    public void EnsureGreaterThan_ThrowsException_WhenValueIsNotGreaterThanMin(int value, int min)
    {
        // Act
        var act = () => Validators.EnsureGreaterThan(value, min);

        // Assert
        act.Should().Throw<ValidationException>()
            .WithMessage($"Value {value} is not greater than {min}.");
    }

    [Fact]
    public void EnsureGreaterThanZero_DoesNotThrowException_WhenValueIsGreaterThanZero()
    {
        // Arrange
        const int value = 1;

        // Act
        var act = () => Validators.EnsureGreaterThanZero(value);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void EnsureGreaterThanZero_ThrowsException_WhenValueIsNotGreaterThanZero(int value)
    {
        // Act
        var act = () => Validators.EnsureGreaterThanZero(value);

        // Assert
        act.Should().Throw<ValidationException>()
            .WithMessage($"Value {value} is not greater than 0.");
    }
}