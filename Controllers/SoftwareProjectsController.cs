using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.SoftwareProject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore6.BugTracker.Controllers;

[Authorize]
[Route("api/v1/[controller]")]
[ApiController]
public class SoftwareProjectsController : ControllerBase
{
    private readonly ISoftwareProjectService _softwareProjectService;

    public SoftwareProjectsController(ISoftwareProjectService softwareProjectService)
    {
        _softwareProjectService = softwareProjectService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SoftwareProjectViewModel>>> GetAllAsync()
    {
        return Ok(await _softwareProjectService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SoftwareProjectViewModel>> GetByIdAsync(int id)
    {
        return Ok(await _softwareProjectService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<SoftwareProjectViewModel>> CreateAsync(SoftwareProjectCreateViewModel viewModel)
    {
        return Ok(await _softwareProjectService.CreateAsync(viewModel));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<SoftwareProjectViewModel>> UpdateAsync(int id, SoftwareProjectUpdateViewModel viewModel)
    {
        return Ok(await _softwareProjectService.UpdateAsync(id, viewModel));
    }
}