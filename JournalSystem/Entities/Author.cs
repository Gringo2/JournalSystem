using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Author
    {
       public Guid AuthorId { get; set; }
       public IEnumerable<Paper> Papers { get; set; }
       public Guid InstitutionId { get; set; } 
       public Institution Institution { get; set; }

    }
}
