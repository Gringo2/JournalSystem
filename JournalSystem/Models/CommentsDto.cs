using System;

namespace JournalSystem.Models
{
    public class CommentsDto
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecieverId { get; set; }
        public Guid PaperId { get; set; }
        public string Comment { get; set; }
        public string Comment_Description { get; set; }
        public bool isRead { get; set; }
        public DateTime Created { get; set; }
    }
}
