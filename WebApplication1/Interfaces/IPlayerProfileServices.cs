using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IPlayerProfileServices
    {
        Task<ActionResult<List<PlayerProfile>>> GetAsync();
        Task<PlayerProfile> GetByIdAsync(int id);
        Task<PlayerProfile> CreateAsync(PlayerProfile playerProfile);
        Task<PlayerProfile> UpdateAsync(int id, PlayerProfile playerProfile);
        Task<bool> DeleteAsync(int id);

    }
}
