using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController, Route("api/[controller]"), Produces("application/json")]
    public class ClubController : Controller
    {
        private readonly IClubServices services;

        public ClubController(IClubServices services)
        {
            this.services = services;
        }

        [HttpPost]
        [Route("AddClub")]
        public async Task<ActionResult<Club>> AddClub(Club club)
        {

            await services.AddClubAsync(club);

            return club;
        }

        [HttpGet]
        [Route("GetClubs")]
        public ActionResult<List<Club>> GetClubs()
        {
            var clubItems = services.GetClubs();

            if (clubItems.Count == 0)
            {
                return NotFound();
            }

            return clubItems;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("Get")]
        public ActionResult<Club> Get(int id)
        {
            return services.Get(id);
        }

        // DELETE api/<controller>
        [HttpDelete]
        [Route("Delete")]
        public string  Delete(int id)
        {
            return services.Delete(id);
            
        }

        //UPDATE api/controller
        [HttpPost]
        [Route("Update")]
        public  ActionResult<Club> UpdateClub(int id,Club club)
        {
            return  services.UpdateClub(id, club);
        }
    }
}
