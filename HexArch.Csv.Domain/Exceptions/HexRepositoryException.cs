using System.Runtime.Serialization;

namespace HexArch.Csv.Domain.Exceptions;

[Serializable]
public class HexRepositoryException: HexArchCsvException
{
    public HexRepositoryException()
    {
    }

    public HexRepositoryException(string message) : base(message)
    {
    }

    public HexRepositoryException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected HexRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}