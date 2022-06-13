using System;

namespace JournalSystem.Entities
{
    public class PaperUser
    {
        public Guid PaperId { get; set; }
        public Paper Paper { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
