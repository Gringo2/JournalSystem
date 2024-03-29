﻿using Journal.web.Models;
using System;
using System.Collections.Generic;

namespace Journal.web.Models
{
    public class PaperDto
    {
        public Guid PaperId { get; set; }
        public Guid UserId { get; set; }
        public string Title_name { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string ImgUrl { get; set; }
        public string File_path { get; set; }
        public string Article_File_path { get; set; }
        public int Version { get; set; }
        public int Size { get; set; }
        public int Page_size { get; set; }
        public Guid HopId { get; set; }
        public int Hop_count { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
