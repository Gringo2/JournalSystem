using System;

namespace JournalSystem.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Author Author { get; set; }
        public Editor Editor { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
