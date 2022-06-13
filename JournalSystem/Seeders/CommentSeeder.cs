using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class CommentSeeder
    {
        private readonly DataDbContext _context;
        public CommentSeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new Comments { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Comment = "Health Science", Comment_Description = "Journal of Health Sciences is a general health science journal addressing clinical medicine, public health and biomedical sciences. In rare instances, it covers veterinary medicine.", IsRead = false });
            AddNewType(new Comments { Id = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), Comment = "Social Sciences & Humanities", Comment_Description = "The social sciences focuses on subjects like economics, psychology, and history, while the humanities explore philosophy, languages and literature, and the arts. Students following this pathway develop strong communication and critical thinking skills, as well as an understanding of cultural differences.", IsRead = false });
            AddNewType(new Comments { Id = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), Comment = "Material Sciences & Engineering", Comment_Description = "Materials Science and Engineering  provides an international medium for the publication of theoretical and experimental studies related to the load-bearing capacity of materials as influenced by their basic properties, processing history, microstructure and operating environment.", IsRead = false });
            AddNewType(new Comments { Id = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), Comment = "Life & Biomedical Sciences", Comment_Description = "Journal of Biomedical and Life Science is an interdisciplinary Research Journal for publication of original research work in all major disciplines of biomedical and life science. Doctors are encouraged to contribute interesting case reports.", IsRead = false });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(Comments comment)
        {
            var existingType = _context.Comments.FirstOrDefault(c => c.Comment == comment.Comment);
            if (existingType == null)
            {
                _context.Comments.Add(comment);
            }
        }
    }
}
