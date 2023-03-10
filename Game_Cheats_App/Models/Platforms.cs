using System.ComponentModel.DataAnnotations;

namespace Game_Cheats_App.Models
{
    public class Platforms
    {
        //these are properties and are going to become columns in the table.[Key] is required for each table and is denoting is the PK.
        [Key]
        public int PlatformId { get; set; }
        public string? PlatformName { get; set; } // The ? after type means it can be nullable

        //One platform can have many games, one game can have many platforms
        public List<Platforms_Games>? PlatformsGames { get; set; }

    }
}
