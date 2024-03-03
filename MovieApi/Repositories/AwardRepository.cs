using Microsoft.EntityFrameworkCore;
using MovieApi.Database;
using MovieApi.Entity;

namespace MovieApi.Repositories
{
    public class AwardRepository : IAwardRepository
    {
        private readonly AppDbContext _context;

        public AwardRepository(AppDbContext context)
        {
            _context = context;
        }

        // Method to retrieve all awards
        public async Task<IEnumerable<Award>> GetAllAwards()
        {
            return await _context.Awards.ToListAsync();
        }

        // Method to retrieve an award by ID
        public async Task<Award> GetAwardById(int id)
        {
            return await _context.Awards.FindAsync(id);
        }

        // Method to add a new award
        public async Task AddAward(Award award)
        {
            _context.Awards.Add(award);
            await _context.SaveChangesAsync();
        }

        // Method to update an existing award
        public async Task UpdateAward(Award award)
        {
            _context.Entry(award).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Method to delete an award by ID
        public async Task DeleteAward(int id)
        {
            var award = await _context.Awards.FindAsync(id);
            if (award != null)
            {
                _context.Awards.Remove(award);
                await _context.SaveChangesAsync();
            }
        }
    }
}
