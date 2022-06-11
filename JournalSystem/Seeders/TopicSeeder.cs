using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class TopicSeeder
    {
        private readonly DataDbContext _context;
        public TopicSeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new Topic { TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), TopicName = "Bio-Tech", CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
            AddNewType(new Topic { TopicId = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), TopicName = "Languages", CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
            AddNewType(new Topic { TopicId = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), TopicName = "Astronomy", CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
            AddNewType(new Topic { TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), TopicName = "Pharmacy", CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(Topic topic)
        {
            var existingType = _context.Topics.FirstOrDefault(p => p.TopicName == topic.TopicName);
            if (existingType == null)
            {
                _context.Topics.Add(topic);
            }
        }
    }
}
