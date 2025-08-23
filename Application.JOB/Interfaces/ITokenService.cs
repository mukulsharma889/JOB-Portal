using Application.JOB.Modals.Auth.Login;
using Application.JOB.Modals.Auth.Register;
using Application.JOB.Modals.Common;

namespace Application.JOB.Interfaces;

public interface ITokenService
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request);   
    Task<Result<string>> RegisterAsync(RegisterRequest request);   
}
