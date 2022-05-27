using System;
using System.Collections.Generic;

namespace JournalSystem.Models
{
    public class TopicDto
    {
        public Guid TopicId { get; set; }
        public string Topic_name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        //public IEnumerable<Paper> Papers { get; set; }
        public Guid CategoryId { get; set; }
        //public Category Category { get; set; }

    }
}
