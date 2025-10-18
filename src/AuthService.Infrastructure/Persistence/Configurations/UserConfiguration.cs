using AuthService.Domain.Users;
using AuthService.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthService.Infrastructure.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> cfg)
    {
        cfg.ToTable("users");
        cfg.HasKey(x => x.Id);

        // Email como Owned Type (VO)
        cfg.OwnsOne(x => x.Email, v =>
        {
            v.Property(p => p.Value)
             .HasColumnName("email")
             .HasMaxLength(256)
             .IsRequired();

            v.HasIndex(p => p.Value).IsUnique();
        });

        // UserName como Owned Type (VO)
        cfg.OwnsOne(x => x.UserName, v =>
        {
            v.Property(p => p.Value)
             .HasColumnName("username")
             .HasMaxLength(50)
             .IsRequired();

            v.HasIndex(p => p.Value).IsUnique();
        });

        cfg.Property(x => x.PasswordHash)
           .HasColumnName("password_hash")
           .IsRequired();

        cfg.Property(x => x.IsProfileCompleted)
           .HasColumnName("is_profile_completed")
           .HasDefaultValue(false);

        cfg.Property(x => x.CreatedAt)
           .HasColumnName("created_at")
           .HasDefaultValueSql("NOW()");

        cfg.Property(x => x.UpdatedAt)
           .HasColumnName("updated_at");

        // Location como Owned Type (VO)
        cfg.OwnsOne(x => x.Location, v =>
        {
            v.Property(p => p.Country).HasColumnName("country").HasMaxLength(80);
            v.Property(p => p.State).HasColumnName("state").HasMaxLength(80);
            v.Property(p => p.City).HasColumnName("city").HasMaxLength(120);
        });

        cfg.Property<int?>("Age")
           .HasColumnName("age");

        // Relação com RefreshTokens configurada do lado do token
        cfg.Navigation(x => x.RefreshTokens).AutoInclude(false);
    }
}
