using System;
using WebApplication1.Models.Dtos.Club;
using WebApplication1.Models.Dtos.PlayerProfile;

namespace WebApplication1.Models.Dtos.Player
{
    public class PlayerGet
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Gender { get; set; }
        public ClubGetName ClubGetName { get; set; }
        public PlayerProfileGetName PlayerProfile { get; set; }
    }
}
