using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.Dtos.Club;

namespace WebApplication1.Controllers
{
    [ApiController, Route("api/[controller]"), Produces("application/json")]
    public class ClubController : Controller
    {
        private readonly IClubServices services;
        private readonly IMapper mapper;

        public ClubController(IClubServices services, IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ClubPost>> Create(Club club)
        {
            try
            {
                await services.CreateAsync(club);

                var clubPost = mapper.Map<ClubPost>(club);
                return clubPost;
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ClubGet>>> Get()
        {
            try
            {
                var clubItems = await services.GetAsync();

                if (!clubItems.Any())
                {
                    return NotFound();
                }
                var clubs = mapper.Map<List<ClubGet>>(clubItems);

                return clubs;
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
        [HttpPut("{id}")]
        public async Task<ActionResult<ClubPut>> UpdateAsync(int id, Club club)
        {
            try
            {
                var result = await services.UpdateAsync(id, club);

                if (result is null)
                {
                    return NotFound();
                }

                ClubPut clubPut = mapper.Map<ClubPut>(result);
                return clubPut;
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }
    }
}
