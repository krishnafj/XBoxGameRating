using Microsoft.EntityFrameworkCore;
using XBoxGameRating.DBModels;

namespace XBoxGameRating
{
    public class GameDBContext : DbContext
    {
        public GameDBContext(DbContextOptions<GameDBContext> options)
            : base(options)
        {

        }

        public DbSet<Games> Games { get; set; }

        public DbSet<GameVotes> GameVotes { get; set; }
    }
}
