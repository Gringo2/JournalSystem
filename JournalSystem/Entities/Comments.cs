using System;

namespace JournalSystem.Entities
{
    public class Comments
    {
        public Guid Id { get; set; }
        public Guid? SenderId { get; set; }
        public Guid? RecieverId { get; set; }
        public Guid? PaperId { get; set; }
        public Paper Paper { get; set; }
        public string Comment { get; set; }
        public string Comment_Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? Created { get; set; }

       
    }

}