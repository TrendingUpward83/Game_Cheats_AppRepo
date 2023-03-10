using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        //Need foreign key for property Platform so that each game show's it's linked Platform- but I don't want Id's to show in my
        //views so....not sure what to do about that


        //Also is this overkill since the relationships are already set up? Can't I access this stuff later through the relationships?
        public int? PlatformId { get; set; }

        [ForeignKey("PlatformId")]
        public Platforms? Platform { get; set; } //I hope I will be able to access/show Game properties by doing this...


    }
}
