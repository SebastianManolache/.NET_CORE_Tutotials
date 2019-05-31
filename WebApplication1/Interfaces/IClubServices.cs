using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IClubServices
    {
        Task<Club> AddClubAsync(Club items);
        List<Club> GetClubs();
        string Delete(int id);
        Club Get(int id);
        Club UpdateClub (int id,Club club);
    }
}
