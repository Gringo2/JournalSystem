using System;
using System.Collections.Generic;

namespace JournalSystem.Entities
{
    public class Hop
    {
        public Guid Id { get; set; }
        public Guid Sender_Id { get; set; }
        public Guid Reciever_Id { get; set; }
        public Guid Paper_Id { get; set; }
        // this is put here as a place holder and will be replaced by actions instead of edit decisions
        // public int Edit_Decisions_Id { get; set; }
        public bool Notify { get; set; }
        public DateTime Date_Created { get; set; }
        public IEnumerable<Paper> Papers { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }

    }
}
