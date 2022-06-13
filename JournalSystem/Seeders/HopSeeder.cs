using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class HopSeeder
    {
        private readonly DataDbContext _context;
        public HopSeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new Hop { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), StatusId = 1 , EditDecisionsId = 1 , Notify = true , PaperId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")});
            AddNewType(new Hop { Id = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), StatusId = 2 , EditDecisionsId = 2 , Notify = true , PaperId = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6") });
            AddNewType(new Hop { Id = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), StatusId = 3 , EditDecisionsId = 3 , Notify = false , PaperId = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6") });
            AddNewType(new Hop { Id = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), StatusId = 4 , EditDecisionsId = 4 , Notify = false , PaperId = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6") });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(Hop hop)
        {
            var existingType = _context.Hops.FirstOrDefault(c => c.Id == hop.Id);
            if (existingType == null)
            {
                _context.Hops.Add(hop);
            }
        }
    }
}
