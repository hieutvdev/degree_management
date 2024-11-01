using degree_management.application.Dtos.Responses.Auth;

namespace degree_management.application.Services;

public interface IJwtTokenService
{
    string GenerateAccessToken(ApplicationUser user, IEnumerable<string>? roles);
    UserDto GetUserFromClaimToken();
}