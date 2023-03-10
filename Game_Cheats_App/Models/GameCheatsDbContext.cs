using Game_Cheats_App.Models;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Add the relationships here (I think)
            modelBuilder.Entity<Games_Cheats>().HasKey(gc => new
            {
                gc.GameId, gc.CheatId //no s in original properties in class
            });

            modelBuilder.Entity<Games_Cheats>().HasOne(g => g.Games).WithMany(gc =>gc.GamesCheats).HasForeignKey(g => g.GameId);

            modelBuilder.Entity<Games_Cheats>().HasOne(c => c.Cheats).WithMany(gc => gc.GamesCheats).HasForeignKey(c => c.CheatId);


            modelBuilder.Entity<Platforms_Games>().HasKey(pg => new
            {
                pg.GameId,
                pg.PlatformId //no s in original properties in class
            });

            modelBuilder.Entity<Platforms_Games>().HasOne(g => g.Games).WithMany(pg => pg.PlatformsGames).HasForeignKey(g => g.GameId);

            modelBuilder.Entity<Platforms_Games>().HasOne(p => p.Platforms).WithMany(pg => pg.PlatformsGames).HasForeignKey(p => p.PlatformId);


            base.OnModelCreating(modelBuilder);

        }
        //Define the Models/tables
        public DbSet<Cheats> Cheats { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Platforms> Platforms { get; set; }

    }
}