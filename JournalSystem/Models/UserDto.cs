using System;
using System.Collections.Generic;

namespace JournalSystem.Models
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        //public IEnumerable<Paper> Papers { get; set; }
        public Guid InstitutionId { get; set; }
        //public Institution Institution { get; set; }
        public Guid FieldId { get; set; }
        //public Field Field { get; set; }
        public Guid RoleId { get; set; }
        //public IEnumerable<Hop> Hops { get; set; }
    }
}
