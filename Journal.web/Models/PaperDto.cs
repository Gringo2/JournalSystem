using System;
using System.Collections.Generic;

namespace Journal.web.Models
{
    public class PaperDto
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
    }
}
