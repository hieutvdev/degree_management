namespace degree_management.infrastructure.Configurations;

public class JwtConfiguration
{
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}