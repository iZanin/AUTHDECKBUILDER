using AuthService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure;

public static class ServiceCollectionExtensions
{
    // Extensão p/ registrar infraestrutura (DbContext, repositórios, etc.)
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
    {
        var conn = cfg.GetConnectionString("DefaultConnection");

        services.AddDbContext<AuthDbContext>(opt =>
        {
            // Npgsql provider
            opt.UseNpgsql(conn);
        });

        // Aqui registraremos repositórios e serviços (JWT, Hash, etc.) mais adiante.

        return services;
    }
}