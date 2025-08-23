using Application.JOB.Interfaces;
using Application.JOB.Modals.Auth.Login;
using Application.JOB.Modals.Auth.Register;
using Application.JOB.Modals.Common;
using Domain.JOB.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.JOB.Services;

public class TokenService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, IConfiguration configuration) : ITokenService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager = roleManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return Result<LoginResponse>.Fail("User not found");
        }

        bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!isPasswordCorrect)
        {
            return Result<LoginResponse>.Fail("Password doesn't match");
        }

        IList<string> currentUserRole = await _userManager.GetRolesAsync(user);

        List<Claim> userClaims =
        [
            new(ClaimTypes.Name, user.Email!)
        ];

        foreach (string role in currentUserRole)
        {
            userClaims.Add(new Claim(ClaimTypes.Role, role));

            IdentityRole<Guid>? roleEntity = await _roleManager.FindByNameAsync(role);
            IList<Claim> rolePermissions = await _roleManager.GetClaimsAsync(roleEntity!);

            foreach (var claim in rolePermissions)
            {
                userClaims.Add(claim);
            }
        }

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken accessToken = new(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: credentials);

        string token = new JwtSecurityTokenHandler().WriteToken(accessToken);

        await _userManager.UpdateAsync(user);

        LoginResponse response = new()
        {
            JwtToken = token,
            TokenExpiry = DateTime.Now.AddHours(24)
        };


        return Result<LoginResponse>.Success(response, "Login successful");
    }


    public async Task<Result<string>> RegisterAsync(RegisterRequest request)
    {
        ApplicationUser? isEmailExists = await _userManager.FindByEmailAsync(request.Email);
        if (isEmailExists is not null)
        {
            return await Result<string>.FailAsync("User already exists");
        }
        ApplicationUser user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Email,
            NormalizedEmail = request.Email.ToUpper().ToUpper(),
        };

        IdentityResult? isUserCreated =  await _userManager.CreateAsync(user, request.Password);

        if (!isUserCreated.Succeeded)
        {
            return await Result<string>.FailAsync("User creation failed. Something went wrong!");
        }

        if(request.Roles.Length != 0 || request.Roles is not null)
        {
            IdentityResult userRoleResult = await _userManager.AddToRolesAsync(user, request.Roles);

            if (!userRoleResult.Succeeded)
            {
                var errors = userRoleResult.Errors.Select(e => e.Description).ToArray();
                return await Result<string>.FailAsync(errors ?? []);
            }

        }
        return await Result<string>.SuccessAsync("User registered successfully");
    }
}
