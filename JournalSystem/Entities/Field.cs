using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Field
    {
        public Guid Id { get; set; }
        public string FieldName { get; set; }
        //public string Specialization { get; set; }
        //public IEnumerable<User> Users { get; set; }
        public IEnumerable<Author> Authors { get; set; } 
        public IEnumerable<Editor> Editors { get; set; }    
        public IEnumerable<Reviewer> Reviewers { get; set; }
    }
}
