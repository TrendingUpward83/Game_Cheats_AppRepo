using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game_Cheats_App.Models
{
    public class Cheats
    {
        [Key]
        public int CheatId { get; set; }
        public string? CheatName { get; set; }

        //One cheat can have many games (same cheat can be used in many games w/ different platforms)//might have to remove 
        public List<Games_Cheats>? GamesCheats { get; set; }

        //Need foreign key for property Game so that each cheat has a unique Game(GameID)- but I don't want Id's to show in my
        //views so....not sure what to do about that
        public int? GameId { get; set; }
        [ForeignKey("GameId")]
        public Games Game { get; set; } //I hope I will be able to access/show Game properties by doing this...

    }
}
