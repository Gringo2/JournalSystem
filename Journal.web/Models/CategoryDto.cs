﻿using System;
using System.Collections.Generic;

namespace Journal.web.Models
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Category_name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
