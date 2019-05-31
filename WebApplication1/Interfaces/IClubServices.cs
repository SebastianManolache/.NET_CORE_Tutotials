﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IClubServices
    {
        Task<Club> CreateAsync(Club items);
        Task<List<Club>> GetAsync();
        Task<Club> GetByIdAsync (int id);
        Task<bool> DeleteAsync(int id);
        Task<Club> UpdateAsync(int id, Club clubDto);

    }
}
