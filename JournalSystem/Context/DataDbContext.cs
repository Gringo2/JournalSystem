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
        
        //public DbSet<EmailTemplates> EmailTemplates { get; set; }
        public DbSet<Hop> Hops { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        //public DbSet<Issues> Issues { get; set; }
        
       
        //public DbSet<NotificationStatus> NotificationStatuses { get; set; }
        public DbSet<Paper> Papers { get; set; }
        
        //public DbSet<Recommendation> Recommendations { get; set; }
        
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Reviewrounds> Reviewersrounds { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var id = Guid.Parse("{eFB88E29-4744-48C0-94FA-B25B92DEA314}");
            modelBuilder.Entity<Hop>().HasData(
                new Hop
                {
                    Id = 1,
                    Sender = "Author",
                    Reciever = "Editor"
                }, 
                new Hop
                {
                    Id = 2,
                    Sender = "Editor",
                    Reciever = "Reviewer"
                }, 
                new Hop
                {
                    Id = 3,
                    Sender = "Reviewer",
                    Reciever = "Editor"
                }, 
                new Hop
                {
                    Id = 4,
                    Sender = "Editor",
                    Reciever = "Author"
                });
            


             
            //public const accept = 1;
            //public const pending_revisions = 2;
            //public const resubmit = 3;
            //public const decline = 4;
            //public const send_to_production = 7;
            //public const external_review = 8;
            //public const recommend_accept = 11;
            //public const recommend_pending_revisions = 12;
            //public const recommend_resubmit = 13;
            //public const recommend_decline = 14;
            //public const new_external_round = 16;
            //public const revert_decline = 17;
            //public const skip_external_review = 19;
            //public const back_to_review = 20;
            //public const back_to_copyediting = 21;
            //public const back_to_submission_from_copyediting = 22;
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
