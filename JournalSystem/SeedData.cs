//// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
//// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

//using IdentityModel;
//using JournalSystem.Context;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Linq;
//using System.Security.Claims;

//namespace AuthServer2._0
//{
//    public class SeedData
//    {
//        public static void EnsureSeedData(string connectionString)
//        {
//            var services = new ServiceCollection();
//            services.AddLogging();
//            services.AddDbContext<DataDbContext>(options =>
//               options.UseSqlite(connectionString));


//            using (var serviceProvider = services.BuildServiceProvider())
//            {
//                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
//                {
//                    var context = scope.ServiceProvider.GetService<DataDbContext>();
//                    context.Database.Migrate();

//                    var Papers = scope.ServiceProvider.GetService<DataDbContext>();
//                    var tecno = Papers.FindAsync("45").Result;
                    
//                }
//            }
//        }
//    }
//}