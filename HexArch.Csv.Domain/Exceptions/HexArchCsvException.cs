using System.Runtime.Serialization;

namespace HexArch.Csv.Domain.Exceptions;

[Serializable]
public class HexArchCsvException : Exception
{
    public HexArchCsvException()
    {
    }

    public HexArchCsvException(string message) : base(message)
    {
    }

    public HexArchCsvException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected HexArchCsvException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}