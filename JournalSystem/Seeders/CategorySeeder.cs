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
            AddNewType(new Category { CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Category_name = "Health Science", Description = "Journal of Health Sciences is a general health science journal addressing clinical medicine, public health and biomedical sciences. In rare instances, it covers veterinary medicine.", ImageUrl = "/images/1.jpg" });
            AddNewType(new Category { CategoryId = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), Category_name = "Social Sciences & Humanities", Description = "The social sciences focuses on subjects like economics, psychology, and history, while the humanities explore philosophy, languages and literature, and the arts. Students following this pathway develop strong communication and critical thinking skills, as well as an understanding of cultural differences.", ImageUrl = "/images/2.jpg" });
            AddNewType(new Category { CategoryId = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), Category_name = "Material Sciences & Engineering", Description = "Materials Science and Engineering  provides an international medium for the publication of theoretical and experimental studies related to the load-bearing capacity of materials as influenced by their basic properties, processing history, microstructure and operating environment.", ImageUrl = "/images/3.jpg" });
            AddNewType(new Category { CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), Category_name = "Life & Biomedical Sciences", Description = "Journal of Biomedical and Life Science is an interdisciplinary Research Journal for publication of original research work in all major disciplines of biomedical and life science. Doctors are encouraged to contribute interesting case reports.", ImageUrl = "/images/4.jpg" });
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
