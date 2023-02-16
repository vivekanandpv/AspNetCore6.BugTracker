using AspNetCore6.BugTracker.Models;

namespace AspNetCore6.BugTracker.ViewModels.Bug;

public class BugUpdateViewModel
{
    public string Description { get; set; }
    public ResolutionStatus ResolutionStatus { get; set; }
}