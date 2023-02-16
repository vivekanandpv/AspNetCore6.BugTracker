using AspNetCore6.BugTracker.Ancillary;
using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Exceptions;
using AspNetCore6.BugTracker.Models;
using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.Bug;
using Microsoft.EntityFrameworkCore;

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
        return await _context.Bugs
            .Include(b => b.Messages)
            .Select(b => ModelMapper.ToViewModel(b))
            .ToListAsync();
    }

    public async Task<IEnumerable<BugViewModel>> GetByProjectIdAsync(int id)
    {
        return await _context.Bugs
            .Include(b => b.Messages)
            .Where(b => b.SoftwareProjectId == id)
            .Select(b => ModelMapper.ToViewModel(b))
            .ToListAsync();
    }

    public async Task<BugViewModel> GetByIdAsync(int id)
    {
        return ModelMapper.ToViewModel(await GetSingleAsync(id));
    }

    public async Task<BugViewModel> CreateAsync(BugCreateViewModel viewModel)
    {
        var project =
            await _context.SoftwareProjects
                .FirstOrDefaultAsync(p =>
                p.SoftwareProjectId == viewModel.SoftwareProjectId);

        if (project == null)
        {
            throw new RecordNotFoundException(
                $"Record {nameof(SoftwareProject)} is not found for id: {viewModel.SoftwareProjectId}");
        }

        //  Create viewmodel is changed in this branch
        var entity = new Bug
        {
            SoftwareProjectId = viewModel.SoftwareProjectId,
            Description = viewModel.Description,
            ReportedOn = viewModel.ReportedOn,
            ResolutionStatus = ResolutionStatus.Open,
            SoftwareProject = project
        };

        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return ModelMapper.ToViewModel(entity);
    }

    public async Task<BugViewModel> UpdateAsync(int id, BugUpdateViewModel viewModel)
    {
        var entity = await GetSingleAsync(id);

        //  Update viewmodel is changed in this branch
        entity.Description = viewModel.Description;
        
        await _context.SaveChangesAsync();

        return ModelMapper.ToViewModel(entity);
    }

    private async Task<Bug> GetSingleAsync(int id)
    {
        var entity = await _context.Bugs
            .Include(s => s.Messages)
            .FirstOrDefaultAsync(e => e.BugId == id);

        if (entity == null)
        {
            throw new RecordNotFoundException($"Record: {nameof(Bug)} not found for id: {id}");
        }

        return entity;
    }
}