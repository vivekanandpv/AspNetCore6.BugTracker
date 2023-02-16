using AspNetCore6.BugTracker.Models;

namespace AspNetCore6.BugTracker.ViewModels.Bug;

public class BugCreateViewModel
{
    public int SoftwareProjectId { get; set; }
    public DateTime ReportedOn { get; set; }
    public string Description { get; set; }
    public ResolutionStatus ResolutionStatus { get; set; }
}