using HexArch.Csv.AppServices.Api.Interfaces;
using HexArch.Csv.AppServices.Api.Models;
using HexArch.Csv.AppServices.Api.Services;
using HexArch.Csv.Infrastructure.Di.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure()
    .AddAppSettings()
    .AddScoped<IApiAppService, ApiAppService>()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = builder.Environment.ApplicationName,
            Version = "v1"
        });
    });
;

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
    $"{builder.Environment.ApplicationName} v1"));

app.MapPost(
    "/",
    (IApiAppService appService, [FromBody] AddFromPayloadRequest request) => appService.Add(request));

app.Run();