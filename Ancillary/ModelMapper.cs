using AspNetCore6.BugTracker.Models;
using AspNetCore6.BugTracker.ViewModels.Bug;
using AspNetCore6.BugTracker.ViewModels.Message;
using AspNetCore6.BugTracker.ViewModels.SoftwareProject;

namespace AspNetCore6.BugTracker.Ancillary
{
    public static class ModelMapper
    {
        public static SoftwareProjectViewModel ToViewModel(SoftwareProject entity)
        {
            return new SoftwareProjectViewModel
            {
                Description = entity.Description,
                Bugs = entity.Bugs.Select(ToViewModel).ToList(),
                CreatedOn = entity.CreatedOn,
                Name = entity.Name,
                SoftwareProjectId = entity.SoftwareProjectId
            };
        }

        public static BugViewModel ToViewModel(Bug entity)
        {
            return new BugViewModel
            {
                BugId = entity.BugId,
                SoftwareProjectId = entity.SoftwareProjectId,
                Description = entity.Description,
                ReportedOn = entity.ReportedOn,
                ResolutionStatus = entity.ResolutionStatus,
                Messages = entity.Messages.Select(ToViewModel).ToList()
            };
        }

        public static MessageViewModel ToViewModel(Message entity)
        {
            return new MessageViewModel
            {
                BugId = entity.BugId,
                CreatedOn = entity.CreatedOn,
                IsResolved = entity.IsResolved,
                MessageDescription = entity.MessageDescription,
                MessageId = entity.MessageId,
                SoftwareProjectId = entity.Bug.SoftwareProjectId
            };
        }
    }
}
