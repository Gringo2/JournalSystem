using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Editor> Editors { get; set; }
        public IEnumerable<Reviewer> Reviewers { get; set; }
    }
}
