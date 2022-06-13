using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class IssueSeeder
    {
        private readonly DataDbContext _context;
        public IssueSeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new Issue { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), JournalName = "Oxford Journal", Volume = 161, Issue_No = 4 });
            AddNewType(new Issue { Id = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), JournalName = "HU Journal", Volume = 71, Issue_No = 3 });
            AddNewType(new Issue { Id = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), JournalName = "AAU Journal", Volume = 12, Issue_No = 7 });
            AddNewType(new Issue { Id = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), JournalName = "Abysinia Journal", Volume = 32, Issue_No = 1 });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(Issue issue)
        {
            var existingType = _context.Issues.FirstOrDefault(c => c.JournalName == issue.JournalName);
            if (existingType == null)
            {
                _context.Issues.Add(issue);
            }
        }
    }
}
