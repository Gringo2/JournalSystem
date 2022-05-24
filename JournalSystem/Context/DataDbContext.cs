using JournalSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace JournalSystem.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) {


        }

        
        

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        //public DbSet<EditDecisions> EditDecisions { get; set; }
        public DbSet<Editor> Editors { get; set; }
        //public DbSet<EmailTemplates> EmailTemplates { get; set; }
        
        public DbSet<Institution> Institutions { get; set; }
        //public DbSet<Issues> Issues { get; set; }
        
       
        //public DbSet<NotificationStatus> NotificationStatuses { get; set; }
        public DbSet<Paper> Papers { get; set; }
        
        //public DbSet<Recommendation> Recommendations { get; set; }
        
        public DbSet<Reviewer> Reviewers { get; set; }
        //public DbSet<Reviewrounds> Reviewersrounds { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var id = Guid.Parse("{eFB88E29-4744-48C0-94FA-B25B92DEA314}");

            //modelBuilder.Entity<Category>().HasData(
            //    new Category()
            //    {
            //         CategoryId = Guid.NewGuid()
            //    });
            //modelBuilder.Entity<Paper>().HasData(
            //       new Paper()
            //       {
            //           PaperId = Guid.NewGuid()
            //       }) ;
            //modelBuilder.Entity<Author>().HasData(
            //    new Author()
            //    {
            //        AuthorId = Guid.NewGuid(),
            //        InstitutionId = Guid.NewGuid()
            //    });
            
            //modelBuilder.Entity<Institution>().HasData(
            //    new Institution()
            //    {
            //       InstitutionId  = Guid.NewGuid()
                   
            //    });
            
        }
    }
           
}
