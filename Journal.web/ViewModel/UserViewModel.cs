using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.ViewModel
{
    public class UserViewModel
    {
        public UserDto User { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid RoleId { get; set; }
    }
}
