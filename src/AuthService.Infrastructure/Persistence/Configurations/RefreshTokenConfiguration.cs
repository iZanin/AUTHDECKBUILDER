using AuthService.Domain.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthService.Infrastructure.Persistence.Configurations;

public sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> cfg)
    {
        cfg.ToTable("refresh_tokens");
        cfg.HasKey(x => x.Id);

        cfg.Property<Guid>("UserId")   // Shadow FK
           .HasColumnName("user_id")
           .IsRequired();

        cfg.Property(x => x.Token)
           .HasColumnName("token")
           .IsRequired();

        cfg.HasIndex(x => x.Token).IsUnique();

        cfg.Property(x => x.ExpiresAt)
           .HasColumnName("expires_at")
           .IsRequired();

        cfg.Property(x => x.CreatedAt)
           .HasColumnName("created_at")
           .HasDefaultValueSql("NOW()");

        cfg.Property(x => x.RevokedAt)
           .HasColumnName("revoked_at");

        cfg.Property(x => x.ReplacedByToken)
           .HasColumnName("replaced_by_token");

        cfg.HasOne(typeof(AuthService.Domain.Users.User))
           .WithMany(nameof(AuthService.Domain.Users.User.RefreshTokens))
           .HasForeignKey("UserId")
           .OnDelete(DeleteBehavior.Cascade);
    }
}