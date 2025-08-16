namespace Application.JOB.Modals.Auth;

public class LoginResponse
{
    public string? JwtToken { get; set; }
    public DateTime? TokenExpiry { get; set; }
}
