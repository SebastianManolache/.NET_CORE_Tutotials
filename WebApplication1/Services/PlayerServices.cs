using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PlayerServices : IPlayerServices
    {
        public async Task<Player> CreateAsync(Player player, int ClubId)
        {
            using (var db = new ClubDbContext())
            {
                var currentClub = await db.Club.FirstOrDefaultAsync(club => club.Id == ClubId);
                player.Club = currentClub;
                //currentClub.Players.Add(player);

                //player.Club.Players.Add(player);
                await db.Player.AddAsync(player);
                await db.SaveChangesAsync();
                return player;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var db = new ClubDbContext())
            {
                var currentPlayer = await db.Player.FirstOrDefaultAsync(player => player.Id == id);
                if (currentPlayer is null) return false;

                db.Player.Remove(currentPlayer);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Player>> GetAsync()
        {
            using (var db = new ClubDbContext())
            {
                var players = await db.Player
                    .Include(p=>p.Club)
                    .ToListAsync();
                return players;
            }
        }

        public async Task<Player> GetByIdAsync(int id)
        {
            using (var db = new ClubDbContext())
            {
                var currentplayer = await db.Player.FirstOrDefaultAsync(player => player.Id == id);
                return currentplayer;
            }
        }

        public async Task<List<Player>> GetPlayersByClubAsync(int clubId)
        {
            using (var db = new ClubDbContext())
            {
                //var currentClub = await db.Club.FirstOrDefaultAsync(club => club.Id == clubId);

                //return currentClub.Players.ToList();
                var players = await db.Player
                    //.Include(p => p.Club)
                    .Where(player => player.ClubId == clubId)
                    .ToListAsync();
                //var clubs = await db.Club.ToListAsync();
                //var currentPlayer = clubs.Join(
                //    players,
                //    club => club.Id,
                //    player => player.Club.Id,
                //    (club, player) => new
                //    {
                //        ClubName = club.Name,
                //        PlayerName = player.DisplayName
                //    });

               return players;

            }
        }

        public async Task<Player> UpdateAsync(int id, Player playerDto)
        {
            using (var db = new ClubDbContext())
            {
                var currentplayer = await db.Player.FirstOrDefaultAsync(player => player.Id == id);
                if (currentplayer is null) return null;

                currentplayer.DisplayName = playerDto.DisplayName;
                currentplayer.DateofBirth = playerDto.DateofBirth;
                currentplayer.FirstName = playerDto.FirstName;
                currentplayer.LastName = playerDto.LastName;
                currentplayer.ClubId = playerDto.ClubId;
                currentplayer.Gender = playerDto.Gender;
                await db.SaveChangesAsync();
                return currentplayer;
            }
        }
    }
}
