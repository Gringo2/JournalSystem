using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Category_name { get; set; }
        public string description { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Paper> Papers { get; set; }
        public IEnumerable<Topic> Topics { get; set; }

    }
}
