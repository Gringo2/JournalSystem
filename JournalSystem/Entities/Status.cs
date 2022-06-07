using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Status
    {
        public int Id { get; set; } 
        public string SenderRole { get; set; }
        public string RecieverRole { get; set; }
        public string StatusName { get; set; }
        public IEnumerable<Hop> Hops { get; set; }
    }
}
