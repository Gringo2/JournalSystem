using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class RoleSeeder
    {
        private readonly DataDbContext _context;
        public RoleSeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new Role { RoleName = "Admin" });
            AddNewType(new Role { RoleName = "Author" });
            AddNewType(new Role { RoleName = "Editor" });
            AddNewType(new Role { RoleName = "Reviewer" });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(Role role)
        {
            var existingType = _context.Roles.FirstOrDefault(c => c.RoleName == role.RoleName);
            if (existingType == null)
            {
                _context.Roles.Add(role);
            }
        }
    }
}
