namespace AuthService.Domain.Users.ValueObjects;

public sealed class UserName
{
    public string Value { get; }

    public UserName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 50)
            throw new ArgumentException("Invalid username length.");
        Value = value.Trim();
    }

    public override bool Equals(object? obj) => obj is UserName other && other.Value == Value;
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value;
}