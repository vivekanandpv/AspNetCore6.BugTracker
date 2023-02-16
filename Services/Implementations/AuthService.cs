using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.Auth;

namespace AspNetCore6.BugTracker.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly BugTrackerContext _context;

    public AuthService(BugTrackerContext context)
    {
        _context = context;
    }

    public async Task RegisterAsync(UserCreateViewModel user)
    {
        throw new NotImplementedException();
    }

    public async Task<JwtViewModel> LoginAsync(LoginViewModel loginViewModel)
    {
        throw new NotImplementedException();
    }
}