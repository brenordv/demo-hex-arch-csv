using HexArch.Csv.AppServices.Api.Models;
using HexArch.Csv.Domain.Exceptions;
using HexArch.Csv.Domain.Validations;

namespace HexArch.Csv.AppServices.Api.Extensions;

public static class AddFromPayloadRequestExtensions
{
    public static void  EnsureIsValid(this AddFromPayloadRequest request)
    {
        if (request is null)
            throw new HexValidationException("Request is null");
        
        Validators.EnsureIsNotEmptyGuid(request.RequestId);
        Validators.EnsureTextIsNotLongerThan(request.Payload, 120000);
        Validators.EnsureDateIsNotMax(request.RequestedAt);
        Validators.EnsureDateIsInPast(request.RequestedAt);
    }
}