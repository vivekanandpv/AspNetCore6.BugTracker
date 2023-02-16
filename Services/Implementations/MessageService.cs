using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.Message;

namespace AspNetCore6.BugTracker.Services.Implementations;

public class MessageService : IMessageService
{
    private readonly BugTrackerContext _context;

    public MessageService(BugTrackerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MessageViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MessageViewModel>> GetByBugIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<MessageViewModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<MessageViewModel> CreateAsync(MessageCreateViewModel viewModel)
    {
        throw new NotImplementedException();
    }

    public async Task<MessageViewModel> UpdateAsync(int id, MessageUpdateViewModel viewModel)
    {
        throw new NotImplementedException();
    }
}