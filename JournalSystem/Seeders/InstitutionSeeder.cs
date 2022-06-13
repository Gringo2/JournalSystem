using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class InstitutionSeeder
    {
        private readonly DataDbContext _context;
        public InstitutionSeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new Institution { InstitutionId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Institutiion_Name = "Hawassa University", Institution_Email = "hawassauniversity@example.com", Institution_Phone = "09876543", Institution_website = "hu.edu.et" });
            AddNewType(new Institution { InstitutionId = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), Institutiion_Name = "Addis Ababa University", Institution_Email = "aau@example.com", Institution_Phone = "099897654", Institution_website = "aau.edu.et" });
            AddNewType(new Institution { InstitutionId = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), Institutiion_Name = "Adama Science and Technology University", Institution_Email = "astu@example.com", Institution_Phone = "0965435665", Institution_website = "astu.edu.et" });
            AddNewType(new Institution { InstitutionId = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), Institutiion_Name = "BahirDar University", Institution_Email = "bahirdaruniversity@example.com", Institution_Phone = "0976545678", Institution_website = "bdu.edu.et" });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(Institution institution)
        {
            var existingType = _context.Institutions.FirstOrDefault(c => c.Institutiion_Name == institution.Institutiion_Name);
            if (existingType == null)
            {
                _context.Institutions.Add(institution);
            }
        }
    }
}
