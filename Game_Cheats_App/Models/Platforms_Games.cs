namespace Game_Cheats_App.Models
{
    public class Platforms_Games
    {
        public int GameId { get; set; }
        public Games? Games { get; set; }
        public int PlatformId { get; set; }
        public Platforms? Platforms { get; set; }
    }
}
