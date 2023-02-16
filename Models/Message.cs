namespace AspNetCore6.BugTracker.Models;

public class Message
{
    public int MessageId { get; set; }
    public int BugId { get; set; }
    public Bug Bug { get; set; }
    public DateTime CreatedOn { get; set; }
    public string MessageDescription { get; set; }
    public bool IsResolved { get; set; }
}