using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class FieldSeeder
    {
        private readonly DataDbContext _context;
        public FieldSeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new Field { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), FieldName = "Engineering", Specialization = "Electrical Engineering" });
            AddNewType(new Field { Id = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), FieldName = "Health Science", Specialization = "Medicine" });
            AddNewType(new Field { Id = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), FieldName = "Law", Specialization = "Criminal Law" });
            AddNewType(new Field { Id = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), FieldName = "Chemistry", Specialization = "Analytical Chemistry" });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(Field field)
        {
            var existingType = _context.Fields.FirstOrDefault(c => c.FieldName == field.FieldName);
            if (existingType == null)
            {
                _context.Fields.Add(field);
            }
        }
    }
}
