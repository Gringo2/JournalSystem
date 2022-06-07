using System;
using System.Collections.Generic;

namespace Auth.Models
{
    public class Field
    {
        public Guid Id { get; set; }
        public string FieldName { get; set; }
        public string Specialization { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
