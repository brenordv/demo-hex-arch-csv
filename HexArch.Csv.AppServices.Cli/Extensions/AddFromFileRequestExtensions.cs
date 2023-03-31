using HexArch.Csv.AppServices.Cli.Models;
using HexArch.Csv.Domain.Exceptions;
using HexArch.Csv.Domain.Validations;

namespace HexArch.Csv.AppServices.Cli.Extensions;

public static class AddFromFileRequestExtensions
{
    public static void EnsureIsValid(this AddFromFileRequest request)
    {
        if (request is null)
            throw new HexValidationException("Request is null");

        Validators.EnsureIsNotEmptyGuid(request.RequestId);
        Validators.EnsureTextIsNotLongerThan(request.Filename, 255);
        Validators.EnsureDateIsNotMax(request.RequestedAt);
        Validators.EnsureDateIsInPast(request.RequestedAt);
    }
}