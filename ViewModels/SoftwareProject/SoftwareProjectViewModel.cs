using AspNetCore6.BugTracker.ViewModels.Bug;

namespace AspNetCore6.BugTracker.ViewModels.SoftwareProject
{
    public class SoftwareProjectViewModel
    {
        public int SoftwareProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public IList<BugViewModel> Bugs { get; set; } = new List<BugViewModel>();
    }
}
