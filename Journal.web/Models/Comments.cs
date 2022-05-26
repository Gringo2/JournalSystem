using Journal.web.Models;
using System;

namespace Journal.web.Entities
{
    public class Comments
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CommentIntendedfor { get; set; }
        public PaperDto Paper { get; set; }
        public string Comment { get; set; }
        public string Comment_Description { get; set; }
        public DateTime Created { get; set; }



       
    }

}