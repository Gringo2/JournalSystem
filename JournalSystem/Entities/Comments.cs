using System;

namespace JournalSystem.Entities
{
    public class Comments
    {
        public Guid CommentId { get; set; }
        public Guid Commentor { get; set; }
        public Guid CommentIntendedfor { get; set; }
    }

}