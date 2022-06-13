using JournalSystem.Context;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Seeders
{
    public class NotificationSeeder
    {
        private readonly DataDbContext _context;
        public NotificationSeeder(DataDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewType(new Notification { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Notification_Header = "Paper Submitted", Notification_Body = "Paper has been submitted for review.", Is_Read = false });
            AddNewType(new Notification { Id = new Guid("3fa85f64-5817-4562-b3fc-2c963f66afa6"), Notification_Header = "Review Process Started", Notification_Body = "Paper is currently being reviewed.", Is_Read = false });
            AddNewType(new Notification { Id = new Guid("3fa85f64-5717-4562-b3ec-2c963f66afa6"), Notification_Header = "Review done", Notification_Body = "The review process has been completed.", Is_Read = false });
            AddNewType(new Notification { Id = new Guid("3fa85f64-5717-4562-b3fc-2c023f66afa6"), Notification_Header = "Decision Made", Notification_Body = "Final decision regarding the paper has been made.", Is_Read = false });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewType(Notification notification)
        {
            var existingType = _context.Notifications.FirstOrDefault(c => c.Notification_Header == notification.Notification_Header);
            if (existingType == null)
            {
                _context.Notifications.Add(notification);
            }
        }
    }
}
