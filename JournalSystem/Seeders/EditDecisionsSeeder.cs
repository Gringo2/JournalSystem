using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class EditDecisionsSeeder
    {
        private readonly DataDbContext _context;
        public EditDecisionsSeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new EditDecisions { Decision = "Accept" });
            AddNewType(new EditDecisions { Decision = "Reject" });
            AddNewType(new EditDecisions { Decision = "Major Modification" });
            AddNewType(new EditDecisions { Decision = "Minor Modification" });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(EditDecisions editDecisions)
        {
            var existingType = _context.EditDecisions.FirstOrDefault(c => c.Decision == editDecisions.Decision);
            if (existingType == null)
            {
                _context.EditDecisions.Add(editDecisions);
            }
        }
    }
}
