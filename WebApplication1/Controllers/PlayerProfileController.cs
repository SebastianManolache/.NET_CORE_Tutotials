using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.Dtos.PlayerProfile;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]"), Produces("application/json")]
    public class PlayerProfileController : Controller
    {
        private readonly IPlayerProfileServices services;
        private readonly IMapper mapper;

        public PlayerProfileController(IPlayerProfileServices services, IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlayerProfileGet>>> GetAsync()
        {
            try
            {
                var result = await services.GetAsync();

                if (result is null)
                {
                    return NotFound();
                }

                 return mapper.Map<List<PlayerProfileGet>>(result);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        // GET api/<controller>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerProfileGet>> GetByIdAsync(int id)
        {
            try
            {
                var result = await services.GetByIdAsync(id);

                if (result is null)
                {
                    return NotFound();
                }

                return mapper.Map<PlayerProfileGet>(result);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<PlayerProfilePost>> CreateAsync([FromBody]PlayerProfile playerProfile)
        {
            try
            {
                await services.CreateAsync(playerProfile);

                return mapper.Map<PlayerProfilePost>(playerProfile);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        // PUT api/<controller>/id
        [HttpPut("{id}")]
        public async Task<ActionResult<PlayerProfilePut>> UpdateAsync(int id, [FromBody]PlayerProfile playerProfile)
        {
            try
            {
                var result = await services.UpdateAsync(id, playerProfile);

                if (result is null)
                {
                    return NotFound();
                }

                return mapper.Map<PlayerProfilePut>( result);
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
    }
}
