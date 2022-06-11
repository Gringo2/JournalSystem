using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.ViewModel
{
    public class HopViewModel
    {
        public HopDto Hop { get; set; }
        public Guid RecievedId { get; set; }
        public Guid PaperId { get; set; }
        public Guid SelectedStatus { get; set; }
        public Guid? SelectedDecision { get; set; }
        public IEnumerable<StatusDto> Statuses { get; set; }
        public IEnumerable<EditDecisionsDto>? EditDecisions { get; set; }

    }
}
