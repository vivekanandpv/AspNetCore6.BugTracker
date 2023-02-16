using AspNetCore6.BugTracker.Ancillary;
using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Exceptions;
using AspNetCore6.BugTracker.Models;
using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.Message;
using Microsoft.EntityFrameworkCore;

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
        return await _context.Messages
            .Select(b => ModelMapper.ToViewModel(b))
            .ToListAsync();
    }

    public async Task<IEnumerable<MessageViewModel>> GetByBugIdAsync(int id)
    {
        return await _context.Messages
            .Where(b => b.BugId == id)
            .Select(b => ModelMapper.ToViewModel(b))
            .ToListAsync();
    }

    public async Task<MessageViewModel> GetByIdAsync(int id)
    {
        return ModelMapper.ToViewModel(await GetSingleAsync(id));
    }

    public async Task<MessageViewModel> CreateAsync(MessageCreateViewModel viewModel)
    {
        var bug =
            await _context.Bugs
                .FirstOrDefaultAsync(p =>
                    p.BugId == viewModel.BugId);

        if (bug == null)
        {
            throw new RecordNotFoundException(
                $"Record {nameof(Bug)} is not found for id: {viewModel.BugId}");
        }

        if (bug.ResolutionStatus == ResolutionStatus.Resolved)
        {
            throw new DomainInvariantException($"This bug is already resolved");
        }

        var entity = new Message
        {
            BugId = viewModel.BugId,
            CreatedOn = viewModel.CreatedOn,
            IsResolved = viewModel.IsResolved,
            MessageDescription = viewModel.MessageDescription,
            Bug = bug
        };

        if (bug.Messages.Count == 0)
        {
            bug.ResolutionStatus = ResolutionStatus.Working;
        }

        if (entity.IsResolved)
        {
            bug.ResolutionStatus = ResolutionStatus.Resolved;
        }

        await _context.AddAsync(entity);

        await _context.SaveChangesAsync();

        return ModelMapper.ToViewModel(entity);
    }

    public async Task<MessageViewModel> UpdateAsync(int id, MessageUpdateViewModel viewModel)
    {
        var entity = await GetSingleAsync(id);

        var resolvedMessage = await _context.Messages
            .Where(m => m.BugId == id)
            .FirstOrDefaultAsync(b => b.IsResolved);

        if (resolvedMessage?.MessageId != id)
        {
            throw new DomainInvariantException($"Bug with id: {entity.BugId} is already resolved");
        }

        entity.MessageDescription = viewModel.MessageDescription;
        entity.IsResolved = viewModel.IsResolved;

        if (entity.IsResolved)
        {
            entity.Bug.ResolutionStatus = ResolutionStatus.Resolved;
        }

        await _context.SaveChangesAsync();

        return ModelMapper.ToViewModel(entity);
    }

    private async Task<Message> GetSingleAsync(int id)
    {
        var entity = await _context.Messages
            .FirstOrDefaultAsync(e => e.BugId == id);

        if (entity == null)
        {
            throw new RecordNotFoundException($"Record: {nameof(Message)} not found for id: {id}");
        }

        return entity;
    }
}