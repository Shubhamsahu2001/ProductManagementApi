namespace ProductManagement.Domain.Entities;

public class RefreshToken
{
    public int Id { get; set; }

    public string Token { get; set; } = string.Empty;

    public DateTime Expires { get; set; }

    public bool IsRevoked { get; set; }

    public string Username { get; set; } = string.Empty;
}