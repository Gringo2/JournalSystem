using System;
using System.Collections.Generic;

namespace Journal.web.Models
{
    public class Institution
    {
        public Guid InstitutionId { get; set; }
        public string Institutiion_Name { set; get; }
        public string Location { get; set; }
        public string Institution_Email { get; set; }
        public string Institution_Phone { get; set; }
        public string Institution_website { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
