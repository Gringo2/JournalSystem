using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Topic
    {
        public Guid TopicId { get; set; }
        public string Topic_name { get; set; }
        public Guid PaperId { get; set; }
        public IEnumerable<Paper> Papers { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<Category> Category { get; set; }

    }
}
