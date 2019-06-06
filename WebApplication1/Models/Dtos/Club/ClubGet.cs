using System;
using System.Collections.Generic;
using WebApplication1.Models.Dtos.Player;

namespace WebApplication1.Models.Dtos.Club
{
    public class ClubGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public DateTime FoundationData { get; set; }
        public List<PlayerGetName> Players { get; set; }
    }
}
