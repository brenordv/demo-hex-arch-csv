using System.Runtime.Serialization;

namespace HexArch.Csv.Domain.Exceptions;

[Serializable]
public class HexRequestException: HexArchCsvException
{
    public HexRequestException()
    {
    }

    public HexRequestException(string message) : base(message)
    {
    }

    public HexRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected HexRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}