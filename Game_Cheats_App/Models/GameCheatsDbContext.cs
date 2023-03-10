using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Game_Cheats_App.Data
{
    public class GameCheatsDbContext : DbContext
    {
        public GameCheatsDbContext(DbContextOptions<GameCheatsDbContext> options)
            : base(options)
        {
        }
    }
}