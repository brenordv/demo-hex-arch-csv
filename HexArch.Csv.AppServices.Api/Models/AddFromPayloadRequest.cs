namespace HexArch.Csv.AppServices.Api.Models;

public record AddFromPayloadRequest
{
    public Guid RequestId { get; } = Guid.NewGuid();
    public DateTime RequestedAt { get; init; } = DateTime.Now;
    public string Payload { get; init; }
}