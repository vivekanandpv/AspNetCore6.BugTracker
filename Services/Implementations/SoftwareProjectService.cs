using AspNetCore6.BugTracker.Ancillary;
using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Exceptions;
using AspNetCore6.BugTracker.Models;
using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.SoftwareProject;
using Microsoft.EntityFrameworkCore;

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
        return await _context.SoftwareProjects
            .Include(s => s.Bugs)
            .ThenInclude(b => b.Messages)
            .Select(s => ModelMapper.ToViewModel(s))
            .ToListAsync();
    }

    public async Task<SoftwareProjectViewModel> GetByIdAsync(int id)
    {
        return ModelMapper.ToViewModel(await GetSingleAsync(id));
    }

    public async Task<SoftwareProjectViewModel> CreateAsync(SoftwareProjectCreateViewModel viewModel)
    {
        var entity = new SoftwareProject
        {
            CreatedOn = viewModel.CreatedOn,
            Description = viewModel.Description,
            Name = viewModel.Name
        };

        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return ModelMapper.ToViewModel(entity);
    }

    public async Task<SoftwareProjectViewModel> UpdateAsync(int id, SoftwareProjectUpdateViewModel viewModel)
    {
        var entity = await GetSingleAsync(id);

        entity.Description = viewModel.Description;
        entity.Name = viewModel.Name;

        await _context.SaveChangesAsync();

        return ModelMapper.ToViewModel(entity);
    }

    private async Task<SoftwareProject> GetSingleAsync(int id)
    {
        var entity = await _context.SoftwareProjects
            .Include(s => s.Bugs)
            .ThenInclude(b => b.Messages)
            .FirstOrDefaultAsync(e => e.SoftwareProjectId == id);

        if (entity == null)
        {
            throw new RecordNotFoundException($"Record: {nameof(SoftwareProject)} not found for id: {id}");
        }

        return entity;
    }
}