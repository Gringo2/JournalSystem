using System;

namespace JournalSystem.Models
{
    public class HopDto
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecieverId { get; set; }
        public int StatusId { get; set; }
        //public Status Status { get; set; }
        public int? EditDecisionsId { get; set; }
        //public EditDecisions EditDecisions { get; set; }
        public bool Notify { get; set; }
        public DateTime Created { get; set; }
        public Guid PaperId { get; set; }
        //public Paper Paper { get; set; }
        public Guid NotificationId { get; set; }
        //public Notification Notifications { get; set; }

    }
}
