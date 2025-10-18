namespace AuthService.Domain.Common;

// Base simples p/ entidades com Id (Guid).
public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}