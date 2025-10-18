using AuthService.Domain.Common;

namespace AuthService.Domain.Sessions;

// Entidade de sessão p/ refresh tokens opacos.
public sealed class RefreshToken : Entity
{
    public Guid UserId { get; private set; }        // FK
    public string Token { get; private set; } = default!;
    public DateTime ExpiresAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? RevokedAt { get; private set; }
    public string? ReplacedByToken { get; private set; }

    private RefreshToken() { } // EF

    public RefreshToken(Guid userId, string token, DateTime expiresAt)
    {
        UserId = userId;
        Token = token;
        ExpiresAt = expiresAt;
        CreatedAt = DateTime.UtcNow;
    }

    public bool IsActive => RevokedAt is null && DateTime.UtcNow < ExpiresAt;

    public void Revoke(string? replacedByToken = null)
    {
        RevokedAt = DateTime.UtcNow;
        ReplacedByToken = replacedByToken;
    }
}