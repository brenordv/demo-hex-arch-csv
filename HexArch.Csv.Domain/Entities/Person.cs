using HexArch.Csv.Domain.Validations;

namespace HexArch.Csv.Domain.Entities;

public record Person
{
    private readonly DateTime _birthDate;
    private readonly int _id;
    private readonly string _name;

    public int Id
    {
        get => _id;
        init
        {
            Validators.EnsureGreaterThanZero(value);
            _id = value;
        }
    }

    public string Name
    {
        get => _name;
        init
        {
            Validators.EnsureTextIsNotLongerThan(value, 50);
            _name = value;
        }
    }

    public DateTime BirthDate
    {
        get => _birthDate;
        init
        {
            Validators.EnsureDateIsNotMax(value);
            Validators.EnsureDateIsInPast(value);
            Validators.EnsureDateIsAfterSqlServerMin(value);
            _birthDate = value.Date;
        }
    }
}