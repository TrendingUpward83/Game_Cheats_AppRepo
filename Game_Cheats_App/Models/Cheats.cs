using System.ComponentModel.DataAnnotations;

namespace Game_Cheats_App.Models
{
    public class Cheats
    {
        [Key]
        public int CheatId { get; set; }
        public string? CheatName { get; set; }

        //One cheat can have many games (same cheat can be used in many games w/ different platforms)//might have to remove 
        public List<Games_Cheats>? GamesCheats { get; set; }
    }
}
