using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Category_name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Topic> Topics { get; set; }

    }
}
