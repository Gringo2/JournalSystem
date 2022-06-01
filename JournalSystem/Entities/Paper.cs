using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Paper
    {
        public Guid PaperId { get; set; }
        public string Title_name { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string ImgUrl { get; set; }
        public string File_path { get; set; }
        public int Version { get; set; }
        public int No_Pages { get; set; }
        public Guid Hop_Id { get; set; }
        public int Hop_count { get; set; }
        public DateTime Created { get; set; }
        public Guid? TopicId { get; set; }
        public Topic Topic { get; set; }
        public IEnumerable<Hop> Hops { get; set; }
        public IEnumerable<User> Users {get; set;}
        public ArticleTemplate Template { get; set; }
        public IEnumerable<Comments> Comments { get; set; }
    }

}
