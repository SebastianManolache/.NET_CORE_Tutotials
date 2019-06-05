using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICollection<Player> Players { get; set; }



        public override bool Equals(object obj)
        {
            if ((obj as Club).Id == Id)
            {
                return true;
            }

            return false;
        }


        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
