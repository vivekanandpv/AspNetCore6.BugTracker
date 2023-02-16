namespace AspNetCore6.BugTracker.Models
{
    public class SoftwareProject
    {
        public int SoftwareProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public IList<Bug> Bugs { get; set; } = new List<Bug>();
    }
}
