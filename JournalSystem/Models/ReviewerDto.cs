﻿using System;

namespace JournalSystem.Models
{
    public class ReviewerDto
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid FieldId { get; set; }
        public int RoleId { get; set; }
    }
}
