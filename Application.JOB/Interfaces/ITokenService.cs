using Application.JOB.Modals.Auth;
using Application.JOB.Modals.Common;

namespace Application.JOB.Interfaces;

public interface ITokenService
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request);   
    Task<Result<string>> RegisterAsync(LoginRequest request);   
}
