using Microsoft.AspNetCore.Identity;
using System;

namespace Auth.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public Guid FieldId { get; set; }
        public Field Field { get; set; }
    }
}
