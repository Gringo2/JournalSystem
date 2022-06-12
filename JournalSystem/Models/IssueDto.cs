using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Models
{
    public class IssueDto
    {
        public Guid Id { get; set; }
        public string JournalName { get; set; }
        public int Volume { get; set; }
        public int Issue_No { get; set; }
        public string Publisher { get; set; }
        public string ImageUrl { get; set; }
        public string FilePath { get; set; }
        public DateTime YearPublished { get; set; }
    }
}
