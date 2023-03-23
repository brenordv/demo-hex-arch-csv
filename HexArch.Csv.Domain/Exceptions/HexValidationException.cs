using System.Runtime.Serialization;

namespace HexArch.Csv.Domain.Exceptions;

[Serializable]
public class HexValidationException: HexArchCsvException
{
    public HexValidationException()
    {
    }

    public HexValidationException(string message) : base(message)
    {
    }

    public HexValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected HexValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}