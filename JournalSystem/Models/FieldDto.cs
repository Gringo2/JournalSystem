using System;

namespace JournalSystem.Models
{
    public class FieldDto
    {
        public Guid Id { get; set; }
        public string FieldName { get; set; }
        public string Specialization { get; set; }
        //public IEnumerable<User> Users { get; set; }
    }
}
