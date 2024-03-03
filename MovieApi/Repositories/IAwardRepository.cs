using MovieApi.Entity;

namespace MovieApi.Repositories
{
    public interface IAwardRepository
    {
        Task<IEnumerable<Award>> GetAllAwards();
        Task<Award> GetAwardById(int id);
        Task AddAward(Award award);
        Task UpdateAward(Award award);
        Task DeleteAward(int id);
    }
}
