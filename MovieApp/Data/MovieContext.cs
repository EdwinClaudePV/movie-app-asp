using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
