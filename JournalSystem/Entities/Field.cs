using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Field
    {
        public Guid Id { get; set; }
        public string FieldName { get; set; }
        public string Specialization { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
