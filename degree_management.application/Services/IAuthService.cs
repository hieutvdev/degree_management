using degree_management.application.Dtos.Requests.Auth;
using degree_management.application.Dtos.Responses.Auth;

namespace degree_management.application.Services;

public interface IAuthService
{
    Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto, CancellationToken cancellationToken = default!);
    
    Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken = default!);
}