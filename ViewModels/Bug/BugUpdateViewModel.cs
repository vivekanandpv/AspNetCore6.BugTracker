using System.ComponentModel.DataAnnotations;
using AspNetCore6.BugTracker.Models;

namespace AspNetCore6.BugTracker.ViewModels.Bug;

public class BugUpdateViewModel
{
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    [Required]
    public ResolutionStatus ResolutionStatus { get; set; }
}