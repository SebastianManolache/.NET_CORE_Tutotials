
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PlayerProfile
    {
        [Key]
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string ShirtNumber { get; set; }
        public string Position { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
