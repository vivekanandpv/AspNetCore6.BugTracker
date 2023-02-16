using System.ComponentModel.DataAnnotations;

namespace AspNetCore6.BugTracker.ViewModels.SoftwareProject;

public class SoftwareProjectUpdateViewModel
{
    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }
}