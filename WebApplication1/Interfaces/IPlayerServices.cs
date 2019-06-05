using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
     public interface IPlayerServices 
    {
        Task<Player > CreateAsync(Player player, int ClubId);
        Task<List<Player>> GetAsync();
        Task<Player> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<Player> UpdateAsync(int id, Player playerDto);
        
        Task<List<Player>> GetPlayersByClubAsync (int CludId);


    }
}
