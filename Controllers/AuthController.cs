using AspNetCore6.BugTracker.ViewModels.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore6.BugTracker.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel viewModel) {
        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserCreateViewModel viewModel) {
        return Ok();
    }
}