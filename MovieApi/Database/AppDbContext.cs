using Microsoft.EntityFrameworkCore;
using MovieApi.Entity;
using System.Diagnostics.Metrics;

namespace MovieApi.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Award> Awards { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Create uniqueness
            modelBuilder.Entity<Movie>()
                .HasIndex(m => m.Title).IsUnique();

            modelBuilder.Entity<Award>()
                .HasIndex(m => m.Name).IsUnique();


            // One movie can have many actors
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies);


            // One movie can have one director
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Cascade);


            // One movie can belong to multiple genres
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genres);

            // One movie can have many reviews
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId);

            // One actor can act in many movies
            modelBuilder.Entity<Actor>()
                .HasMany(a => a.Movies)
                .WithMany(m => m.Actors);

            // One director can direct many movies
            modelBuilder.Entity<Director>()
                .HasMany(d => d.Movies)
                .WithOne(m => m.Director)
                .HasForeignKey(m => m.DirectorId);

            // One review is for one movie
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MovieId);

            //modelBuilder.Entity<Award>()
            //    .HasOne(a => a.Movie)
            //    .WithMany(m => m.Awards)
            //    .HasForeignKey(a => a.MovieId).IsRequired(false)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Award>()
            //    .HasOne(a => a.RecipientDirector)
            //    .WithMany(m => m.Awards)
            //    .HasForeignKey(a => a.DirectorId).IsRequired(false)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Award>()
            //    .HasOne(a => a.RecipientActor)
            //    .WithMany(m => m.Awards)
            //    .HasForeignKey(a => a.ActorId).IsRequired(false)
              //  .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
