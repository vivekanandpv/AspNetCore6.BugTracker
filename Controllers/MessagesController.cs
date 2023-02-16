using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.Bug;
using AspNetCore6.BugTracker.ViewModels.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore6.BugTracker.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessagesController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MessageViewModel>>> GetAllAsync()
    {
        return Ok(await _messageService.GetAllAsync());
    }


    [HttpGet("by-bug/{bugId:int}")]
    public async Task<ActionResult<IEnumerable<MessageViewModel>>> GetByBugIdAsync(int bugId)
    {
        return Ok(await _messageService.GetByBugIdAsync(bugId));
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<MessageViewModel>> GetByIdAsync(int id)
    {
        return Ok(await _messageService.GetByIdAsync(id));
    }


    [HttpPost]
    public async Task<ActionResult<MessageViewModel>> CreateAsync(MessageCreateViewModel viewModel)
    {
        return Ok(await _messageService.CreateAsync(viewModel));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MessageViewModel>> UpdateAsync(int id, MessageUpdateViewModel viewModel)
    {
        return Ok(await _messageService.UpdateAsync(id, viewModel));
    }
}