using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public ICollection<Paper> Papers { get; set; }
        public Guid? InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public Guid? FieldId { get; set; }
        public Field Field { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public IEnumerable<Hop> Hops { get; set; }
    }
}
