using JournalSystem.Entities;
using System.Collections.Generic;

namespace JournalSystem.Models
{
    public class PaperViewModel
    {
        public PaperDto Paper { get; set; }
        public IEnumerable<PaperDto> Papers { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
