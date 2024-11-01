using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using degree_management.application.Dtos.Responses.Auth;
using degree_management.application.Services;
using degree_management.constracts.Exceptions;
using degree_management.domain.Entities;
using degree_management.infrastructure.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace degree_management.infrastructure.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtConfiguration _jwt;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JwtTokenService(UserManager<ApplicationUser> userManager,
        IOptions<JwtConfiguration> options, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _jwt = options.Value;
        _httpContextAccessor = httpContextAccessor;
    }
    public string GenerateAccessToken(ApplicationUser user, IEnumerable<string>? roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Secret));

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim("FullName", user.FullName),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim("Avatar", user.Avatar),
        };

        if (roles is not null && roles.Any())
        {
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r.ToString())));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwt.Issuer,
            Audience = _jwt.Audience,
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
            Expires = DateTime.UtcNow.AddDays(10)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public UserDto GetUserFromClaimToken()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null) {
            throw new BadRequestException("User info is null");
        }

        return new UserDto(
            Id: user?.FindFirst(ClaimTypes.NameIdentifier)!.Value ?? "",
            UserName: user?.FindFirst(ClaimTypes.Name)!.Value ?? "",
            FullName: user?.FindFirst("FullName")!.Value ?? "",
            Avatar: user?.FindFirst("AvatarUrl")!.Value ?? ""

        );
    }
}