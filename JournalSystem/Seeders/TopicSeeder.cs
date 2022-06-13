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
            AddNewType(new Topic { TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), TopicName = "Allergies", Description = "Allergy is a leading, open access, peer reviewed journal covering all areas of research from surgical techniques to diagnostic dilemmas, as well as treatment options and pathophysiologic investigations in sinonasal diseases, as well as asthma and other allergic disorders.", CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
            AddNewType(new Topic { TopicId = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), TopicName = "Hospitalizations", Description = "Journal of Hospital and Healthcare Administration is an online open access journal covers theories, methods and applications in hospital and healthcare administration. This journal includes the leadership, management and administration of public health systems, hospitals and hospital networks.", CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
            AddNewType(new Topic { TopicId = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), TopicName = "Injuries", Description = "Injury Epidemiology is a pioneering, open access journal publishing cutting-edge epidemiologic studies of both intentional and unintentional injuries.", CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
            AddNewType(new Topic { TopicId = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), TopicName = "Surgeries", Description = "Surgery journal features the very best in clinical and laboratory-based research on all aspects of surgical procedures and interventions. Patient care around the peri-operative period and patient outcomes post surgery are key topics for the journal.", CategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") });
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
