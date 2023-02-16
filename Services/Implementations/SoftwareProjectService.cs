using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.SoftwareProject;

namespace AspNetCore6.BugTracker.Services.Implementations;

public class SoftwareProjectService : ISoftwareProjectService
{
    private readonly BugTrackerContext _context;

    public SoftwareProjectService(BugTrackerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SoftwareProjectViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<SoftwareProjectViewModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<SoftwareProjectViewModel> CreateAsync(SoftwareProjectCreateViewModel viewModel)
    {
        throw new NotImplementedException();
    }

    public async Task<SoftwareProjectViewModel> UpdateAsync(int id, SoftwareProjectUpdateViewModel viewModel)
    {
        throw new NotImplementedException();
    }
}