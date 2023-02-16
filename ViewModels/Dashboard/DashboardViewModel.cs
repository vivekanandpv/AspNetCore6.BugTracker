namespace AspNetCore6.BugTracker.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public int TotalProjects { get; set; }
        public int TotalBugsReported { get; set; }
        public int TotalMessages { get; set; }
        public int TotalResolvedBugs { get; set; }
        public int TotalUnresolvedBugs { get; set; }
        public double? ResolutionRate { get; set; } //  What if no bugs reported so far?
    }
}
