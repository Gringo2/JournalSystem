using System;

namespace Journal.web.Models
{
    public class ArticleTemplateDto
    {
        public Guid Id { get; set; }
        public Guid PaperId { get; set; }
        public string FilePath { get; set; }
        public int Version { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
