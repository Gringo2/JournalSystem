using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid Hop_Id { get; set; }
        public string Notification_Header { get; set; }
        public string Notification_Body { get; set; }
        public bool Is_Read { get; set; }
        public DateTime Date_Created { get; set; }

    }
}
