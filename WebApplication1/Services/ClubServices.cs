using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;


namespace WebApplication1.Services
{
    public class ClubServices : IClubServices
    {
        
        public async Task<Club> AddClubAsync(Club club)
        {
            using (var db = new ClubDbContext())
            {
                var clubItems = db.Clubs.ToList();
                await db.Clubs.AddAsync(club);
                await db.SaveChangesAsync();
                clubItems = db.Clubs.ToList();
            }
            return club;
        }

       
        public List<Club> GetClubs()
        {
            var salesDal = new ClubDbContext();
            var clubItems = salesDal.Clubs.ToList();

            return clubItems;
        }

        
        public Club Get(int id)
        {
            var salesDal = new ClubDbContext();
            var clubs = salesDal.Clubs.ToList();

            var club1= clubs.FirstOrDefault(club => club.Id == id);
            if (club1 == null)
                return new Club();
            return club1;
        }

        public string Delete(int id)
        {
            var salesDal = new ClubDbContext();
            var clubs = salesDal.Clubs.ToList();

            var c = clubs.FirstOrDefault(club => club.Id == id);
            if (c == null)
                return "This club is not found";
            salesDal.Clubs.RemoveRange(c);
            salesDal.SaveChanges();
            return $"The club with id={ id} is deleted";
        }

        public Club UpdateClub(int id, Club club)
        {
            using (var db = new ClubDbContext())
            {
                var clubs = db.Clubs.ToList();
                var club1 = clubs.FirstOrDefault(c => c.Id == id);
                if (club1 == null)
                {
                    return new Club();
                }
                else
                {
                    club1.Cooch = club.Cooch;
                    club1.FoundationData = club.FoundationData;
                    club1.Name = club.Name;
                    db.Clubs.Update(club1);
                    db.SaveChanges();
                }
                return club1;
            }
        }
    }
}
