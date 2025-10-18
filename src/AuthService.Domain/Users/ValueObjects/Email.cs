namespace AuthService.Domain.Users.ValueObjects;

public sealed class Email
{
    // VO imutável. Mantemos apenas a "Value" e validamos no construtor.
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
            throw new ArgumentException("Invalid email.");
        Value = value.Trim().ToLowerInvariant();
    }

    // VOs devem implementar igualdade por valor.
    public override bool Equals(object? obj) => obj is Email other && other.Value == Value;
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value;
}