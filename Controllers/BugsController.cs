using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.Bug;
using AspNetCore6.BugTracker.ViewModels.SoftwareProject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore6.BugTracker.Controllers;

[Authorize]
[Route("api/v1/[controller]")]
[ApiController]
public class BugsController : ControllerBase
{
    private readonly IBugService _bugService;

    public BugsController(IBugService bugService)
    {
        _bugService = bugService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BugViewModel>>> GetAllAsync()
    {
        return Ok(await _bugService.GetAllAsync());
    }


    [HttpGet("by-project/{projectId:int}")]
    public async Task<ActionResult<IEnumerable<BugViewModel>>> GetByProjectIdAsync(int projectId)
    {
        return Ok(await _bugService.GetByProjectIdAsync(projectId));
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<BugViewModel>> GetByIdAsync(int id)
    {
        return Ok(await _bugService.GetByIdAsync(id));
    }
        

    [HttpPost]
    public async Task<ActionResult<BugViewModel>> CreateAsync(BugCreateViewModel viewModel)
    {
        return Ok(await _bugService.CreateAsync(viewModel));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<BugViewModel>> UpdateAsync(int id, BugUpdateViewModel viewModel)
    {
        return Ok(await _bugService.UpdateAsync(id, viewModel));
    }
}