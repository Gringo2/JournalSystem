using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Models
{
    public class StatusDto
    {
        public int Id { get; set; }
        public string SenderRole { get; set; }
        public string RecieverRole { get; set; }
        public string StatusName { get; set; }
    }
}
