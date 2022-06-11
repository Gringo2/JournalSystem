//using JournalSystem.Context;
//using JournalSystem.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace JournalSystem.Seeders
//{
//    public class TestDataSeeder
//    {
//        private readonly DataDbContext _context;
//        public TestDataSeeder(DataDbContext context)
//        {
//            _context = context;
//        }

//        public void SeedData()
//        {
//            _context.Papers.Add(new Paper
//            {
//                PaperId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
//                Title_name = "Test Post 1",
//                Abstract = "This is my standard post for testing",
//                Status = 1,
//                Version = 1,
//                No_Pages = 1,
//                HopCount = 1,
//                Created = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"),
//                Published = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"),
//                TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
//            });
//            _context.Papers.Add(new Paper
//            {
//                PaperId = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"),
//                Title_name = "Languages",
//                Status = 1,
//                Version = 1,
//                No_Pages = 1,
//                HopCount = 1,
//                Created = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"),
//                Published = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"),
//                TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
//            });
//            _context.Papers.Add(new Paper
//            {
//                PaperId = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"),
//                Title_name = "Astronomy",
//                Status = 1,
//                Version = 1,
//                No_Pages = 1,
//                HopCount = 1,
//                Created = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"),
//                Published = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"),
//                TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
//            });
//            _context.Papers.Add(new Paper
//            {
//                PaperId = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"),
//                Title_name = "Pharmacy",
//                Status = 1,
//                Version = 1,
//                No_Pages = 1,
//                HopCount = 1,
//                Created = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"),
//                Published = Convert.ToDateTime("2022 - 06 - 10T22:14:00.791Z"),
//                TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
//            });

//            _context.Topics.Add(new Topic
//            {
//                TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
//                TopicName = "Bio-Tech",
//                CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
//            });
//            _context.Topics.Add(new Topic
//            {
//                TopicId = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"),
//                TopicName = "Languages",
//                CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
//            });
//            _context.Topics.Add(new Topic
//            {
//                TopicId = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"),
//                TopicName = "Astronomy",
//                CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
//            });
//            _context.Topics.Add(new Topic
//            {
//                TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"),
//                TopicName = "Pharmacy",
//                CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
//            });


//            _context.Categories.Add(new Category
//            {
//                CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
//                Category_name = "Bio-Tech"
//            });
//            _context.Categories.Add(new Category
//            {
//                CategoryId = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"),
//                Category_name = "Languages"
//            });
//            _context.Categories.Add(new Category
//            {
//                CategoryId = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"),
//                Category_name = "Astronomy"
//            });
//            _context.Categories.Add(new Category
//            {
//                CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"),
//                Category_name = "Pharmacy"
//            });


//            _context.SaveChanges();
//        }
//    }
//}
