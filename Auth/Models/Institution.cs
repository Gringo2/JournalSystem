﻿using System;
using System.Collections.Generic;

namespace Auth.Models
{
    public class Institution
    {
        public Guid InstitutionId { get; set; }
        public string Institutiion_Name { set; get; }
        public string Location { get; set; }
        public string Institution_Email { get; set; }
        public string Institution_Phone { get; set; }
        public string Institution_website { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}