using System.ComponentModel.DataAnnotations;
using AspNetCore6.BugTracker.Models;

namespace AspNetCore6.BugTracker.ViewModels.Bug;

public class BugCreateViewModel
{
    [Required]
    [Range(0, Int32.MaxValue)]
    public int SoftwareProjectId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "2000-01-01", "2099-12-31", ErrorMessage = "ReportedOn should be within {1} and {2}")]

    public DateTime ReportedOn { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
}