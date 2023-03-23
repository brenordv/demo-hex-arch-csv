using HexArch.Csv.Domain.Interfaces.Repositories;
using HexArch.Csv.Domain.Interfaces.Services;
using HexArch.Csv.Domain.Services.Services;
using HexArch.Csv.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HexArch.Csv.Infrastructure.Di.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        
        services.AddSingleton(typeof(IConfiguration), configuration);
        services.AddRepositories();
        services.AddServices();
        services.AddLogging();
        return services;
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IPeopleRepository, PeopleRepository>();
        return services;
    }
    
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPeopleService, PeopleService>();
        return services;
    }
}