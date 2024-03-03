using Microsoft.EntityFrameworkCore;
using MovieApi.Database;
using MovieApi.Entity;

namespace MovieApi.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        // Method to retrieve all movies
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var result = await _context.Movies
                .Include(x => x.Actors)
                .Include(x => x.Genres)
                .Include(x => x.Director)
                .Include(x => x.Reviews)
                .Include(x => x.Awards)
                .ToListAsync();
            return result;
        }

        // Method to retrieve a movie by ID
        public async Task<Movie> GetMovieById(int id)
        {
            return await _context.Movies
                .Include(x => x.Actors)
                .Include(x => x.Genres)
                .Include(x => x.Director)
                .Include(x => x.Reviews)
                .Include(x => x.Awards)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Method to add a new movie
        public async Task AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        // Method to update an existing movie
        public async Task UpdateMovie(Movie movie)
        {
            var movieToUpdate = await _context.Movies.FindAsync(movie.Id);
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = movie.Title;
                movieToUpdate.IMDbRating = movie.IMDbRating;
                movieToUpdate.ReleaseDate = movie.ReleaseDate;
                movieToUpdate.Duration = movie.Duration;
                movieToUpdate.Summary = movie.Summary;
            }

            await _context.SaveChangesAsync();
        }

        // Method to delete a movie by ID
        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Actor> GetActorById(int id)
        {
            return await _context.Actors
                .Include(x => x.Movies)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
                
        }
    }
}
