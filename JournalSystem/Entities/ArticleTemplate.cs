using System;

namespace JournalSystem.Entities
{
    public class ArticleTemplate
    {
        public Guid Id { get; set; }
        public Guid PaperId { get; set; }
        public Paper Paper { get; set; }
        public string FilePath { get; set; }
        public int Version { get; set; }
        public int Size { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
