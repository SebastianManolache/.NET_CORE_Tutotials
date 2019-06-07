using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Coach { get; set; }
        public DateTime FoundationData { get; set; }
        public List<Player> Players { get; set; }
    }
}
