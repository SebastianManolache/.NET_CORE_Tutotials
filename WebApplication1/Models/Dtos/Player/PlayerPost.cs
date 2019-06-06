using System;
using WebApplication1.Models.Dtos.Club;

namespace WebApplication1.Models.Dtos.Player
{
    public class PlayerPost
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Gender { get; set; }
        public ClubGetName ClubGetName { get; set; }
    }
}
