using AspNetCore6.BugTracker.ViewModels.SoftwareProject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore6.BugTracker.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SoftwareProjectsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftwareProjectViewModel>>> GetAllAsync()
        {
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SoftwareProjectViewModel>> GetByIdAsync(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<SoftwareProjectViewModel>> CreateAsync(SoftwareProjectCreateViewModel viewModel)
        {
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SoftwareProjectViewModel>> UpdateAsync(int id, SoftwareProjectUpdateViewModel viewModel)
        {
            return Ok();
        }
    }
}
