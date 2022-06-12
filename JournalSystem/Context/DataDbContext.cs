using JournalSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace JournalSystem.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) {


        }

        
        

        public DbSet<ArticleTemplate> ArticleTemplates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<EditDecisions> EditDecisions { get; set; }
       // public DbSet<Field> Field { get; set; }
        public DbSet<Hop> Hops { get; set; }
        //public DbSet<Institution> Institutions { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
       
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var id = Guid.Parse("{eFB88E29-4744-48C0-94FA-B25B92DEA314}");
            


             
            

        }
    }
           
}
