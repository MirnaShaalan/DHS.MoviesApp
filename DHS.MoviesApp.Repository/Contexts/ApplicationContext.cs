using DHS.MoviesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHS.MoviesApp.Repository.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
           new Movie { Id= new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"), Name ="Movie 1" },
           new Movie { Id = new Guid("12223344-2566-7788-99AA-BBCCDDEEFF00"),Name = "Movie 2"},
           new Movie { Id = new Guid("13223344-3566-7788-99AA-BBCCDDEEFF00"), Name = "Movie 3"}
       );
        }



    }
}
