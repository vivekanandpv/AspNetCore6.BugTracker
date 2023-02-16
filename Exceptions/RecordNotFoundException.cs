namespace AspNetCore6.BugTracker.Exceptions;

public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(string message) : base(message)
    {
            
    }
}