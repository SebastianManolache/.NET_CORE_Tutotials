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
        public string Cooch { get; set; }
        public DateTime FoundationData { get; set; }
        public Club()
        {
            Id = 0;
        }
    }
    

    class ClubComparer : IEqualityComparer<Club>
    {
        public bool Equals(Club x, Club y)
        {
            if (x.Id == y.Id)
                return true;

            return false;
        }

        public int GetHashCode(Club club)
        {
            return club.Id.GetHashCode();
        }
    }
}
