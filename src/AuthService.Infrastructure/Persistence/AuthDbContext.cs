using AuthService.Domain.Sessions;
using AuthService.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Persistence;

// DbContext da aplicação (banco auth_db)
public sealed class AuthDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder b)
    {
        // Importa configurações por assembly (boa prática p/ manter limpo)
        b.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
    }
}