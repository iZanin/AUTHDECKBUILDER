using AuthService.Domain.Common;
using AuthService.Domain.Sessions;
using AuthService.Domain.Users.ValueObjects;

namespace AuthService.Domain.Users;

// Aggregate Root: User
public sealed class User : Entity
{
    public Email Email { get; private set; } = default!;
    public UserName UserName { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;

    public bool IsProfileCompleted { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    // Dados de perfil (podem ser VO/Owned Types no EF)
    public Location? Location { get; private set; }
    public int? Age { get; private set; }

    // Navegação p/ refresh tokens (1..n)
    public ICollection<RefreshToken> RefreshTokens { get; private set; } = new List<RefreshToken>();

    private User() { } // EF

    private User(Email email, UserName userName, string passwordHash)
    {
        Email = email;
        UserName = userName;
        PasswordHash = passwordHash;
        IsProfileCompleted = false; // cadastro começa incompleto
    }

    public static User Create(Email email, UserName userName, string passwordHash)
        => new(email, userName, passwordHash);

    public void UpdateProfile(Location location, int? age)
    {
        Location = location;
        Age = age;
        IsProfileCompleted = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdatePasswordHash(string newHash)
    {
        PasswordHash = newHash;
        UpdatedAt = DateTime.UtcNow;
    }
}