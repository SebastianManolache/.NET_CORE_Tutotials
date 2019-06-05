using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]"), Produces("application/json")]
    public class PlayerProfileController : Controller
    {
        private readonly IPlayerProfileServices services;

        public PlayerProfileController(IPlayerProfileServices services)
        {
            this.services = services;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<List<PlayerProfile>>> GetAsync()
        {
            try
            {
                var result = await services.GetAsync();

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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerProfile>> GetByIdAsync(int id)
        {
            try
            {
                var result = await services.GetByIdAsync(id);

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

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<PlayerProfile>> CreateAsync([FromBody]PlayerProfile playerProfile)
        {
            try
            {
                await services.CreateAsync( playerProfile);

                return playerProfile;
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PlayerProfile>> UpdateAsync(int id, [FromBody]PlayerProfile playerProfile)
        {
            try
            {
                var result = await services.UpdateAsync(id, playerProfile);

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

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
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
    }
}
