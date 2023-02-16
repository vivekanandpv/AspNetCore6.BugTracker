using AspNetCore6.BugTracker.ViewModels.Bug;
using AspNetCore6.BugTracker.ViewModels.SoftwareProject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore6.BugTracker.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BugsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BugViewModel>>> GetAllAsync()
    {
        return Ok();
    }


    [HttpGet("by-project/{projectId:int}")]
    public async Task<ActionResult<IEnumerable<BugViewModel>>> GetByProjectIdAsync(int projectId)
    {
        return Ok();
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<BugViewModel>> GetByIdAsync(int id)
    {
        return Ok();
    }
        

    [HttpPost]
    public async Task<ActionResult<BugViewModel>> CreateAsync(BugCreateViewModel viewModel)
    {
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<BugViewModel>> UpdateAsync(int id, BugUpdateViewModel viewModel)
    {
        return Ok();
    }
}