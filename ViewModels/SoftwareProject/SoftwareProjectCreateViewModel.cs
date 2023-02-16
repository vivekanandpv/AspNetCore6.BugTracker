using System.ComponentModel.DataAnnotations;

namespace AspNetCore6.BugTracker.ViewModels.SoftwareProject;

public class SoftwareProjectCreateViewModel
{
    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "2000-01-01", "2099-12-31", ErrorMessage = "CreatedOn should be within {1} and {2}")]
    public DateTime CreatedOn { get; set; }
}