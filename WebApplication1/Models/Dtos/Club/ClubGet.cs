using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Dtos.Club
{
    public class ClubGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public DateTime FoundationData { get; set; }
    }
}
