using System.Runtime.Serialization;

namespace HexArch.Csv.Domain.Exceptions;

[Serializable]
public class HexServiceException : HexArchCsvException
{
    public HexServiceException()
    {
    }

    public HexServiceException(string message) : base(message)
    {
    }

    public HexServiceException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected HexServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}