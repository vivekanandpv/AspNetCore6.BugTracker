using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Models;
using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.Dashboard;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore6.BugTracker.Services.Implementations;

class DashboardService : IDashboardService
{
    private readonly BugTrackerContext _context;

    public DashboardService(BugTrackerContext context)
    {
        _context = context;
    }

    public async Task<DashboardViewModel> GetStatisticsAsync()
    {
        var totalProjects = await _context.SoftwareProjects.CountAsync();
        var totalBugsReported = await _context.Bugs.CountAsync();
        var totalMessages = await _context.Messages.CountAsync();
        var totalResolvedBugs = await _context.Bugs.CountAsync(b => b.ResolutionStatus == ResolutionStatus.Resolved);
        var totalUnresolvedBugs = totalBugsReported - totalResolvedBugs;

        return new DashboardViewModel
        {
            TotalProjects = totalProjects,
            TotalBugsReported = totalBugsReported,
            TotalMessages = totalMessages,
            TotalResolvedBugs = totalResolvedBugs,
            TotalUnresolvedBugs = totalUnresolvedBugs,
            ResolutionRate = totalBugsReported != 0 ? Convert.ToDouble(totalResolvedBugs) / Convert.ToDouble(totalBugsReported) : null
        };
    }
}