using System;
using System.Collections.Generic;

namespace Journal.web.Models
{
    public class TopicDto
    {
        public Guid TopicId { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
