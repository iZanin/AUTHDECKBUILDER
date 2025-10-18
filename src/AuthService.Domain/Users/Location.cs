namespace AuthService.Domain.Users.ValueObjects;

// Início simples: País/Estado/Cidade. Podemos evoluir p/ lat/long depois.
public sealed class Location
{
    public string? Country { get; }
    public string? State   { get; }
    public string? City    { get; }

    public Location(string? country, string? state, string? city)
    {
        Country = string.IsNullOrWhiteSpace(country) ? null : country.Trim();
        State   = string.IsNullOrWhiteSpace(state)   ? null : state.Trim();
        City    = string.IsNullOrWhiteSpace(city)    ? null : city.Trim();
    }
}