using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.Dtos.Club;
using Microsoft.AspNetCore.Mvc.Abstractions;

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
        public async Task<IActionResult> Create(Club club)
        {
            try
            {
                await services.CreateAsync(club);

                var clubPost = mapper.Map<ClubPost>(club);

                return Ok(clubPost);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clubItems = await services.GetAsync();

                if (!clubItems.Any())
                {
                    return NotFound();
                }
                var clubs = mapper.Map<List<ClubGet>>(clubItems);

                return Ok(clubs);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: api/<controller>
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await services.GetByIdAsync(id);

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

        // DELETE api/<controller>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
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
                return BadRequest(e);
            }
        }

        //UPDATE api/controller
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Club club)
        {
            try
            {
                var result = await services.UpdateAsync(id, club);

                if (result is null)
                {
                    return NotFound();
                }

                ClubPut clubPut = mapper.Map<ClubPut>(result);

                return Ok(clubPut);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException.Message}");
            }
        }
    }
}
