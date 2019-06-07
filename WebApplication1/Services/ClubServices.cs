using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ClubServices : IClubServices
    {
        public async Task<Club> CreateAsync(Club club)
        {
            using (var db = new ClubDbContext())
            {
                await db.Club.AddAsync(club);
                await db.SaveChangesAsync();
                return club;
            } 
        }

        public async Task<List<Club>> GetAsync()
        {
            using (var db = new ClubDbContext())
            {
                var clubs = await db.Club
                    .Include(club => club.Players)
                    .ToListAsync();
                return clubs;
            }
        }

        public async Task<Club> GetByIdAsync (int id)
        {
            using (var db = new ClubDbContext())
            {
                var currentclub = await db.Club
                    .Include(club => club.Players)
                    .FirstOrDefaultAsync(club => club.Id == id);
                return currentclub;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var db = new ClubDbContext())
            {
                var currentClub = await db.Club.FirstOrDefaultAsync(club => club.Id == id);
                if (currentClub is null) return false;

                db.Club.Remove(currentClub);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Club> UpdateAsync(int id,[FromBody] Club clubDto)
        {
            using (var db = new ClubDbContext())
            {
                var currentClub = await db.Club.FirstOrDefaultAsync(club => club.Id == id);
                if (currentClub is null) return null;

                currentClub.Coach = clubDto.Coach;
                currentClub.FoundationData = clubDto.FoundationData;
                currentClub.Name = clubDto.Name;
                db.Club.Update(currentClub);
                await db.SaveChangesAsync();

                return currentClub;
            }
        }
    }
}
