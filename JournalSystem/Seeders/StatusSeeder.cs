using JournalSystem.Context;
using JournalSystem.Entities;
using System.Linq;

namespace JournalSystem.Seeders
{
    public class StatusSeeder
    {
        private readonly DataDbContext _context;
        public StatusSeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new Status { StatusName = "Submitted" });
            AddNewType(new Status { StatusName = "Under Editorial Review" });
            AddNewType(new Status { StatusName = "Sent For Review" });
            AddNewType(new Status { StatusName = "Under Review" });
            AddNewType(new Status { StatusName = "Under Editorial Review" });
            AddNewType(new Status { StatusName = "Decision Made" });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(Status status)
        {
            var existingType = _context.Statuses.FirstOrDefault(c => c.StatusName == status.StatusName);
            if (existingType == null)
            {
                _context.Statuses.Add(status);
            }
        }
    }
}
