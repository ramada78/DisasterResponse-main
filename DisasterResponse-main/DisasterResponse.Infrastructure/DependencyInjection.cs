using DisasterResponse.Domain.Repositories;
using DisasterResponse.Infrastructure.Context;
using DisasterResponse.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DisasterResponse.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DisasterDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped(typeof(IRepository), typeof(Repository));
        return services;
    }
}