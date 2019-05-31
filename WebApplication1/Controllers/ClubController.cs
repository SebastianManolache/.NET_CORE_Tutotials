using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<Club>> Create(Club club)
        {
            try
            {
                await services.CreateAsync(club);

                return club;
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Club>>> Get()
        {
            try
            {
                var clubItems = await services.GetAsync();

                if (!clubItems.Any())
                {
                    return NotFound();
                }

                return clubItems;
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        // GET: api/<controller>
        [HttpGet("byId/{id}")]
        public async Task<ActionResult<Club>> GetByIdAsync(int id)
        {
            try
            {
                var result =  await services.GetByIdAsync(id);

                if (result is null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        // DELETE api/<controller>
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                if (await services.DeleteAsync(id))
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        //UPDATE api/controller
        [HttpPut]
        public async Task<ActionResult<Club>> UpdateAsync(int id, Club club)
        {
            try
            {
                var result = await services.UpdateAsync(id,club);

                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }
    }
}
