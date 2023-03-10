using System.ComponentModel.DataAnnotations;

namespace Game_Cheats_App.Models
{
    public class Games
    {
        [Key]
        public int GameId { get; set; }
        public string? GameName { get; set; }

        //Relationships

        //One game can have many cheats, one cheat can have many games
        public List<Games_Cheats>? GamesCheats { get; set; }

        //One platform can have many games, one game can have many platforms
        public List<Platforms_Games>? PlatformsGames { get; set; }


    }
}
