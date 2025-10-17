using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuthService.Infrastructure.Persistence;

namespace AuthService.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuração do DbContext
        services.AddDbContext<AuthDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            options.UseNpgsql(connectionString);
        });

        // Registro de repositórios e serviços será adicionado aqui
        // services.AddScoped<IUserRepository, UserRepository>();
        // services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        // services.AddScoped<IJwtService, JwtService>();
        // services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}