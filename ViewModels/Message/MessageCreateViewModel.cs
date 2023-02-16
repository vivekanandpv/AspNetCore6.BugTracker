namespace AspNetCore6.BugTracker.ViewModels.Message;

public class MessageCreateViewModel
{
    public int BugId { get; set; }
    public DateTime CreatedOn { get; set; }
    public string MessageDescription { get; set; }
    public bool IsResolved { get; set; }
}