using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PlayerProfileServices : IPlayerProfileServices
    {
        public async Task<PlayerProfile> CreateAsync(PlayerProfile playerProfile)
        {
            using (var db = new ClubDbContext())
            {
                var currentPlayer = await db.Player.FirstOrDefaultAsync(player => player.Id == playerProfile.PlayerId);
                currentPlayer.PlayerProfile = playerProfile;

                //playerProfile.Player = currentPlayer;
                //currentPlayer.PlayerProfile = playerProfile;

                await db.PlayerProfile.AddAsync(playerProfile);
                await db.SaveChangesAsync();
                return playerProfile;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var db = new ClubDbContext())
            {
                var currentProfile = await db.PlayerProfile.FirstOrDefaultAsync(profile => profile.Id == id);
                if (currentProfile is null) return false;

                db.PlayerProfile.Remove(currentProfile);
                await db.SaveChangesAsync();

                return true;
            }
        }

        public async Task<ActionResult<List<PlayerProfile>>> GetAsync()
        {
            using (var db = new ClubDbContext())
            {
                var profiles = await db.PlayerProfile.ToListAsync();
                return profiles;
            }
        }

        public async Task<PlayerProfile> GetByIdAsync(int id)
        {
            using (var db = new ClubDbContext())
            {
                var currentProfile = await db.PlayerProfile.FirstOrDefaultAsync(profile => profile.Id == id);
                return currentProfile;
            }
        }

        public async Task<PlayerProfile> UpdateAsync(int id, PlayerProfile playerProfileDto)
        {
            using (var db = new ClubDbContext())
            {
                var currentProfile = await db.PlayerProfile.FirstOrDefaultAsync(profile => profile.Id == id);
                if (currentProfile is null) return null;

                currentProfile.Height = playerProfileDto.Height;
                currentProfile.Weight = playerProfileDto.Weight;
                currentProfile.Position = playerProfileDto.Position;
                currentProfile.ShirtNumber = playerProfileDto.ShirtNumber;
                currentProfile.ShortName = playerProfileDto.ShortName;
                db.PlayerProfile.Update(currentProfile);
                await db.SaveChangesAsync();

                return currentProfile;
            }
        }
    }
}
