using System.ComponentModel.DataAnnotations;

namespace AspNetCore6.BugTracker.ViewModels.Message;

public class MessageCreateViewModel
{
    [Required]
    [Range(0, Int32.MaxValue)]
    public int BugId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "2000-01-01", "2099-12-31", ErrorMessage = "CreatedOn should be within {1} and {2}")]
    public DateTime CreatedOn { get; set; }

    [Required]
    [MaxLength(500)]
    public string MessageDescription { get; set; }

    [Required]
    public bool IsResolved { get; set; }
}