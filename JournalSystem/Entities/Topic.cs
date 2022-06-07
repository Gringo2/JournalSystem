using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Topic
    {
        public Guid TopicId { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Paper> Papers { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
