using System;

namespace WebApplication1.Models.Dtos.Club
{
    public class ClubPut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public DateTime FoundationData { get; set; }
        
    }
}
