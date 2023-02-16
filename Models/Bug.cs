namespace AspNetCore6.BugTracker.Models;

public class Bug    
{
    public int BugId { get; set; }
    public int SoftwareProjectId { get; set; }
    public SoftwareProject SoftwareProject { get; set; }
    public DateTime ReportedOn { get; set; }
    public string Description { get; set; }
    public ResolutionStatus ResolutionStatus { get; set; }
    public IList<Message> Messages { get; set; } = new List<Message>();
}