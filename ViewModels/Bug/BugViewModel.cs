using AspNetCore6.BugTracker.Models;
using AspNetCore6.BugTracker.ViewModels.Message;

namespace AspNetCore6.BugTracker.ViewModels.Bug;

public class BugViewModel
{
    public int BugId { get; set; }
    public int SoftwareProjectId { get; set; }
    public DateTime ReportedOn { get; set; }
    public string Description { get; set; }
    public ResolutionStatus ResolutionStatus { get; set; }
    public IList<MessageViewModel> Messages { get; set; } = new List<MessageViewModel>();
}