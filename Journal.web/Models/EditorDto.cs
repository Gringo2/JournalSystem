﻿using System;

namespace JournalSystem.web.Models
{
    public class EditorDto
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid FieldId { get; set; }
        public int RoleId { get; set; }
    }
}
