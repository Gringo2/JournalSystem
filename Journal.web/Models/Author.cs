using System;
using System.Collections.Generic;

namespace Journal.web.Models
{
    public class Author
    {
       public Guid AuthorId { get; set; }
       public IEnumerable<PaperDto> Papers { get; set; }
       public Guid InstitutionId { get; set; } 
       public Institution Institution { get; set; }

    }
}
