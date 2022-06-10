using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.ViewModel
{
    public class NotificationViewModel
    {
        public NotificationDto Notification { get; set; }
        public Guid Hop_Id { get; set; }
    }
}
