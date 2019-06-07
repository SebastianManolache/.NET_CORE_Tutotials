using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.Dtos.Player;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]"), Produces("application/json")]
    public class PlayerController : Controller
    {
        private readonly IPlayerServices services;
        private readonly IMapper mapper;

        public PlayerController(IPlayerServices services, IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PlayerPost>> Create([FromBody] Player player, int clubId)
        {
            try
            {
                await services.CreateAsync(player, clubId);
                return mapper.Map<PlayerPost>(player);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<PlayerGet>>> Get()
        {
            try
            {
                var players = await services.GetAsync();

                if (!players.Any())
                {
                    return NotFound();
                }

                return mapper.Map<List<PlayerGet>>(players);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        // GET api/<controller>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerGet>> GetByIdAsync(int id)
        {
            try
            {
                var result = await services.GetByIdAsync(id);

                if (result is null)
                {
                    return NotFound();
                }

                return mapper.Map<PlayerGet>(result);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        // PUT api/<controller>/id
        [HttpPut("{id}")]
        public async Task<ActionResult<PlayerPut>> UpdateAsync(int id, [FromBody]Player player)
        {
            try
            {
                var currentPlayer = await services.UpdateAsync(id, player);

                if (currentPlayer is null)
                {
                    return NotFound();
                }

                return mapper.Map<PlayerPut>(currentPlayer);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }


        // DELETE api/<controller>/id
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
        public async Task<ActionResult<List<PlayerGet>>> GetClubPlayersAsync(int id)
        {
            try
            {

                var players = await services.GetPlayersByClubAsync(id);

                if (players is null || !players.Any())
                {
                    return NotFound();
                }

                return mapper.Map<List<PlayerGet>>(players);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }
    }
}
