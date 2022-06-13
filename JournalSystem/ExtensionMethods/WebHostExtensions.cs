using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using JournalSystem.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using JournalSystem.Seeders;

namespace JournalSystem.ExtensionMethods
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<DataDbContext>();

                // now we have the DbContext. Run migrations
                //context.Database.Migrate();

                // now that the database is up to date. Let's seed
                new RoleSeeder(context).SeedData();
                new CategorySeeder(context).SeedData();
                new TopicSeeder(context).SeedData();
                new EditDecisionsSeeder(context).SeedData();
                new FieldSeeder(context).SeedData();
                new InstitutionSeeder(context).SeedData();
                new StatusSeeder(context).SeedData();
                new NotificationSeeder(context).SeedData();
                new PaperSeeder(context).SeedData();
                new HopSeeder(context).SeedData();
                new CommentSeeder(context).SeedData();
                new IssueSeeder(context).SeedData();
                
                

#if DEBUG
                // if we are debugging, then let's run the test data seeder
                // alternatively, check against the environment to run this seeder
                //new TestDataSeeder(context).SeedData();
#endif
            }

            return host;
        }
    }
}
