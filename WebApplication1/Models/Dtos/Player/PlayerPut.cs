using WebApplication1.Models.Dtos.Club;

namespace WebApplication1.Models.Dtos.Player
{
    public class PlayerPut
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
       public ClubGetName ClubGetName { get; set; }
    }
}
