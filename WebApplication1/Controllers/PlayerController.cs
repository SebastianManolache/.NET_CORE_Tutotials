using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]"), Produces("application/json")]
    public class PlayerController : Controller
    {
        private readonly IPlayerServices services;

        public PlayerController(IPlayerServices services)
        {
            this.services = services;
        }



        [HttpPost]
        public async Task<ActionResult<Player>> Create([FromBody] Player player, int clubId)
        {
            try
            {
                await services.CreateAsync(player, clubId);
                return player;
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<Player>>> Get()
        {
            try
            {
                var players = await services.GetAsync();

                if (!players.Any())
                {
                    return NotFound();
                }

                return players;
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetByIdAsync(int id)
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


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Player>> UpdateAsync(int id, [FromBody]Player player)
        {
            try
            {
                var currentPlayer = await services.UpdateAsync(id, player);

                if (currentPlayer is null)
                {
                    return NotFound();
                }

                return currentPlayer;
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
        [HttpGet("getclubplayers/{id}")]
        public async Task<ActionResult<List<Player>>> GetClubPlayersAsync(int id)
        {
            try
            {
                
                var players = await services.GetPlayersByClubAsync(id);

                if (players is null || !players.Any())
                {
                    return NotFound();
                }

                return players;
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }
    }
}
