using AspNetCore6.BugTracker.ViewModels.Bug;
using AspNetCore6.BugTracker.ViewModels.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore6.BugTracker.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MessageViewModel>>> GetAllAsync()
    {
        return Ok();
    }


    [HttpGet("by-bug/{bugId:int}")]
    public async Task<ActionResult<IEnumerable<MessageViewModel>>> GetByBugIdAsync(int bugId)
    {
        return Ok();
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<MessageViewModel>> GetByIdAsync(int id)
    {
        return Ok();
    }


    [HttpPost]
    public async Task<ActionResult<MessageViewModel>> CreateAsync(MessageCreateViewModel viewModel)
    {
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MessageViewModel>> UpdateAsync(int id, MessageUpdateViewModel viewModel)
    {
        return Ok();
    }
}