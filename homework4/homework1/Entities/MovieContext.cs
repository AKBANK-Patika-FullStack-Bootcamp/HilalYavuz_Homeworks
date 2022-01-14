using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MovieContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=LAPTOP-N7FBE5OG; Database=Movie; integrated security=True;");
            

        }
        public DbSet<Movie> movie { get; set; }
        public DbSet<Details> details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Details>().ToTable("Details");
        }

    }
}
