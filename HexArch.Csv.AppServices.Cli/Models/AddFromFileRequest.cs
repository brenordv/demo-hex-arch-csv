namespace HexArch.Csv.AppServices.Cli.Models;

public record AddFromFileRequest
{
    public Guid RequestId { get; } = Guid.NewGuid();
    public DateTime RequestedAt { get; init; } = DateTime.Now;
    public string Filename { get; init; }

    public static implicit operator FileInfo(AddFromFileRequest request)
    {
        return new(request.Filename);
    }
}