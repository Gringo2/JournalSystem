using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class EditDecisions
    {

        public int  Id { get; set; }
        public string Decision { get; set; }
        public IEnumerable<Hop> Hops { get; set; }

    }
}
