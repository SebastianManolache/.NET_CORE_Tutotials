using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Gender { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public PlayerProfile PlayerProfile { get; set; }
    }
}
