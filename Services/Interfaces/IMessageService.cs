using AspNetCore6.BugTracker.ViewModels.Message;

namespace AspNetCore6.BugTracker.Services.Interfaces;

public interface IMessageService
{
    Task<IEnumerable<MessageViewModel>> GetAllAsync();
    Task<IEnumerable<MessageViewModel>> GetByBugIdAsync(int id);
    Task<MessageViewModel> GetByIdAsync(int id);
    Task<MessageViewModel> CreateAsync(MessageCreateViewModel viewModel);
    Task<MessageViewModel> UpdateAsync(int id, MessageUpdateViewModel viewModel);
}