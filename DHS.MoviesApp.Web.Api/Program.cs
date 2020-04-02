using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DHS.MoviesApp.Repository.Contexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DHS.MoviesApp.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();


            using (var context = new ApplicationContext(null))
            {
                context.Database.EnsureCreated();

                var testBlog = context.Movies.Count();
                if (testBlog ==0)
                {
                    context.Movies.Add(new Domain.Entities.Movie { Name="Movie 1" });
                }
                context.SaveChanges();
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
