using WebApplication1.Models.Dtos.Player;

namespace WebApplication1.Models.Dtos.PlayerProfile
{
    public class PlayerProfilePut
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string ShirtNumber { get; set; }
        public string Position { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public PlayerGetName Player { get; set; }
    }
}
