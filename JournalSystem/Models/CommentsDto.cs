using System;

namespace JournalSystem.Models
{
    public class CommentsDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PaperId { get; set; }
       // public Paper Paper { get; set; }
        public string Comment { get; set; }
        public string Comment_Description { get; set; }
        public DateTime Created { get; set; }
    }
}
