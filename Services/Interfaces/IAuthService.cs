using AspNetCore6.BugTracker.ViewModels.Auth;

namespace AspNetCore6.BugTracker.Services.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(UserCreateViewModel user);
    Task<JwtViewModel> LoginAsync(LoginViewModel loginViewModel);
}