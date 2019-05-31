using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Managers
{
    public class ClubLayer
    {
        public List<Club> GetClubs()
        {
            using (var db = new ClubDbContext())
            {
                var clubs = db
                    .Club
                    .ToListAsync().Result;
                return clubs;
            }
        }

        public async Task<Club> SaveClubAsync(Club club)
        {
            using (var db = new ClubDbContext())
            {
                db.Club.Add(club);
                await db.SaveChangesAsync();
            }
            return club;
        }

        public void UploadClubs(List<Club> clubs)
        {
            var db = new ClubDbContext(); // TODO using context dispose
            db.Club.AddRange(clubs);
            db.SaveChanges();
        }
    }
}
