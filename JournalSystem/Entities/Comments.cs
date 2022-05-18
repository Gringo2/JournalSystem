using System;

namespace JournalSystem.Entities
{
    public class Comments:User
    {
        
        public Guid CommentIntendedfor { get; set; }
        public Paper Paper { get; set; }

       
    }

}