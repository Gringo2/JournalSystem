using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class PaperSeeder
    {
            private readonly DataDbContext _context;
            public PaperSeeder(DataDbContext context)
            {
                _context = context;
            }

            public void SeedData()
            {
                AddNewType(new Paper { PaperId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Title_name = "Bio-Tech", Status = 1, Version = 1, No_Pages = 1, HopCount = 1, Created = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"), Published = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"), TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
                AddNewType(new Paper { PaperId = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), Title_name = "Languages", Status = 1, Version = 1, No_Pages = 1, HopCount = 1, Created = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"), Published = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"), TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
                AddNewType(new Paper { PaperId = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), Title_name = "Astronomy", Status = 1, Version = 1, No_Pages = 1, HopCount = 1, Created = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"), Published = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"), TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
                AddNewType(new Paper { PaperId = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), Title_name = "Pharmacy", Status = 1, Version = 1, No_Pages = 1, HopCount = 1, Created = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"), Published = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"), TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
                _context.SaveChanges();
            }

            // since we run this seeder when the app starts
            // we should avoid adding duplicates, so check first
            // then add
            private void AddNewType(Paper paper)
            {
                var existingType = _context.Papers.FirstOrDefault(p => p.Title_name == paper.Title_name);
                if (existingType == null)
                {
                    _context.Papers.Add(paper);
                }
            }
    }
}
