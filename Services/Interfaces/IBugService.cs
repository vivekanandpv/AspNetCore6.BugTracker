using AspNetCore6.BugTracker.ViewModels.Bug;

namespace AspNetCore6.BugTracker.Services.Interfaces;

public interface IBugService
{
    Task<IEnumerable<BugViewModel>> GetAllAsync();
    Task<IEnumerable<BugViewModel>> GetByProjectIdAsync(int id);
    Task<BugViewModel> GetByIdAsync(int id);
    Task<BugViewModel> CreateAsync(BugCreateViewModel viewModel);
    Task<BugViewModel> UpdateAsync(int id, BugUpdateViewModel viewModel);
}