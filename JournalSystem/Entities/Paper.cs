using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Paper
    {
        public Guid PaperId { get; set; }
        public string Title_name { get; set; }
        public string Abstract { get; set; }
        public int Status { get; set; }
        public string ImageUrl { get; set; }
        public string FilePath { get; set; }
        public int Version { get; set; }
        public int No_Pages { get; set; }
        public int HopCount { get; set; }
        public DateTime Created { get; set; }
        public DateTime Published { get; set; }
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
        public IEnumerable<Hop> Hops { get; set; }
        public ICollection<User> Users {get; set;}
        public ArticleTemplate ArticleTemplate { get; set; }
        public IEnumerable<Comments> Comments { get; set; }
    }

}
