using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.Bug;

namespace AspNetCore6.BugTracker.Services.Implementations;

public class BugService : IBugService
{
    private readonly BugTrackerContext _context;

    public BugService(BugTrackerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BugViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BugViewModel>> GetByProjectIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BugViewModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BugViewModel> CreateAsync(BugCreateViewModel viewModel)
    {
        throw new NotImplementedException();
    }

    public async Task<BugViewModel> UpdateAsync(int id, BugUpdateViewModel viewModel)
    {
        throw new NotImplementedException();
    }
}