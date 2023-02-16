namespace AspNetCore6.BugTracker.ViewModels.Message;

public class MessageViewModel
{
    public int MessageId { get; set; }
    public int BugId { get; set; }
    public int SoftwareProjectId { get; set; }
    public DateTime CreatedOn { get; set; }
    public string MessageDescription { get; set; }
    public bool IsResolved { get; set; }
}