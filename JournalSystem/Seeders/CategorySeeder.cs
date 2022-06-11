using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class CategorySeeder
    {
        private readonly DataDbContext _context;
        public CategorySeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new Category { CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Category_name = "Bio-Tech" });
            AddNewType(new Category { CategoryId = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), Category_name = "Languages" });
            AddNewType(new Category { CategoryId = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), Category_name = "Astronomy" });
            AddNewType(new Category { CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), Category_name = "Pharmacy" });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(Category category)
        {
            var existingType = _context.Categories.FirstOrDefault(c => c.Category_name == category.Category_name);
            if (existingType == null)
            {
                _context.Categories.Add(category);
            }
        }
    }
}
