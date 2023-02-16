using AspNetCore6.BugTracker.ViewModels.SoftwareProject;

namespace AspNetCore6.BugTracker.Services.Interfaces;

public interface ISoftwareProjectService
{
    Task<IEnumerable<SoftwareProjectViewModel>> GetAllAsync();
    Task<SoftwareProjectViewModel> GetByIdAsync(int id);
    Task<SoftwareProjectViewModel> CreateAsync(SoftwareProjectCreateViewModel viewModel);
    Task<SoftwareProjectViewModel> UpdateAsync(int id, SoftwareProjectUpdateViewModel viewModel);
}