﻿using System;
using System.Collections.Generic;

namespace Journal.web.Models
{
    public class UserDto
    {
        public Guid UserId { get; set; }
       //ublic IEnumerable<Paper> Papers { get; set; }
        public Guid InstitutionId { get; set; }
       //public Institution Institution { get; set; }
        public Guid RoleId { get; set; }
    }
}