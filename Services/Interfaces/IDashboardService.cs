using AspNetCore6.BugTracker.ViewModels.Dashboard;

namespace AspNetCore6.BugTracker.Services.Interfaces;

public interface IDashboardService
{
    Task<DashboardViewModel> GetStatisticsAsync();
}