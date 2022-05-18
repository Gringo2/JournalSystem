using System;

namespace JournalSystem.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserRole { get; set; }
        public string UserName { get; set; }
    }
}
