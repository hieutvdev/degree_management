using AutoMapper;
using degree_management.application.Dtos.Requests.Auth;
using degree_management.application.Dtos.Responses.Auth;
using degree_management.application.Services;
using degree_management.constracts.Exceptions;
using degree_management.domain.Entities;
using degree_management.infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;

namespace degree_management.infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IJwtTokenService _jwt;
    private readonly UserManager<ApplicationUser> _user;
    private readonly IMapper _mapper;
    public AuthService(IJwtTokenService jwt, UserManager<ApplicationUser> user, IMapper mapper)
    {
        _jwt = jwt;
        _user = user;
        _mapper = mapper;
    }
    public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto, CancellationToken cancellationToken = default)
    {
        try
        {
            var checkUser = await _user.FindByEmailAsync(registerRequestDto.UserName);
            if (checkUser is not null)
            {
                throw new BadRequestException("User is exists");
            }

            var user = new ApplicationUser
            {
                
                Email = registerRequestDto.UserName,
                UserName = registerRequestDto.UserName,
                FullName = registerRequestDto.FullName,
                Avatar = ""
            };
            var result = await _user.CreateAsync(user, registerRequestDto.Password);
            if (!result.Succeeded)
            {
                throw new BadRequestException(result.Errors.FirstOrDefault()!.Description.ToString());
            }

            var token = _jwt.GenerateAccessToken(user, null);

            return new RegisterResponseDto(_mapper.Map<UserDto>(user), token);
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _user.FindByEmailAsync(loginRequestDto.Email);
            if (user is null)
            {
                throw new BadRequestException("User dont exists");
            }

            if (user.Status == 1)
            {
                // handle check status user
                // 1. 2. 3....
            }

            var checkPass = await _user.CheckPasswordAsync(user, loginRequestDto.Password);
            if (!checkPass)
            {
                throw new BadRequestException("Password is incorrect");
            }

            var roles = await _user.GetRolesAsync(user);
            var token = _jwt.GenerateAccessToken(user, roles);
            return new LoginResponseDto(_mapper.Map<UserDto>(user), token);
        }
        
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}