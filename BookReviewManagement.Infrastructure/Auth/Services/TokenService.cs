namespace BookReviewManagement.Infrastructure.Auth.Services;

public sealed class TokenService(IOptions<JwtSettings> settings) : ITokenService
{
    private readonly JwtSettings _settings = settings.Value;

    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.JwtKey!);
        var claims = user.GetClaims();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(settings.Value.ExpireMinutes),
            Issuer = _settings.Emissary,
            Audience = _settings.ValidOn,
            SigningCredentials = new SigningCredentials(
                key: new SymmetricSecurityKey(key),
                algorithm: SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}