using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastighetsProjectApi_CCRA.Model;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using FastighetsProjectApi_CCRA.Data;
using Microsoft.AspNetCore.Identity;
using FastighetsProjectApi_CCRA.Areas.Identity.Data;
using System.Web.Http.Description;
using FastighetsProjectApi_CCRA.HelpClasses;
using FastighetsProjectApi_CCRA.Contracs;

namespace FastighetsProjectApi_CCRA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RealEstatesController : ControllerBase
    {
        private readonly DbContext _context;
        private readonly IRealEstateRepository _realEstateRepository;

        public RealEstatesController(DbContext context, IRealEstateRepository realEstateRepository)
        {
            _context = context;
            _realEstateRepository = realEstateRepository;
        }
        //[HttpGet] //Försökte lösa httpget med parametrar strulade...
        //[AllowAnonymous]
        //public async Task<ActionResult<IEnumerable<RealEstate>>> GetRealEstates(int skip, int take) => take.HasValue ?
        //    GetRealEstates() : GetRealEstates(skip, take);


        //{
        //    return await _context.RealEstates.OrderBy(d => d.CreatedOn).Take(10).ToListAsync();
        //}


        //GET: api/RealEstates
        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<ActionResult<IEnumerable<RealEstate>>> GetRealEstates()
        //{

        //    return await _context.RealEstates.Include(d => d.Comments).OrderByDescending(d => d.CreatedOn).Take(10).ToListAsync();
        //}

        // GET: api/RealEstates?skip={int}&take={int}
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RealEstate>>> GetRealEstatesQuery([FromQuery] SkipTakeParameters skipTakeParameters)
        {
            var realestates = _realEstateRepository.GetRealEstateST(skipTakeParameters);
            return Ok(realestates);
            //return await _context.RealEstates.Include(d => d.Comments).OrderBy(d => d.CreatedOn).Skip(skip).Take(take).ToListAsync();
        }

        // GET: api/RealEstates/5
        [HttpGet("{id}")]
        [AllowAnonymous]

        [ResponseType(typeof(RealEstateDTO))]
        public async Task<IActionResult> GetRealEstate(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var realEstate = await _context.RealEstates.Include(d => d.Comments).SingleOrDefaultAsync( i => i.ide == id);


                if (realEstate == null)
                {
                    return NotFound();
                }

                return Ok(realEstate);
            }
            else
            {
               var realEstate = await _context.RealEstates.FindAsync(id);
               var Dto = new RealEstateDTO(realEstate);

                return Ok(Dto);
            }
        }
        //Försök att skriva patch för att updatera en grej
        //[HttpPatch("{id}")] 
        //public async Task<IActionResult> UpdateRealEstate(int id)
        //{
        //    _context.Realestate.
        //    Update

        //    return Ok();
        //}

        // PUT: api/RealEstates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRealEstate(int id, RealEstate realEstate)
        {
            if (id != realEstate.ide)
            {
                return BadRequest();
            }

            _context.Entry(realEstate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RealEstates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<RealEstate>> PostRealEstate(RealEstate realEstate)
        {
            _context.RealEstates.Add(realEstate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRealEstate", new { id = realEstate.Id }, realEstate);
        }

        // DELETE: api/RealEstates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealEstate(int id)
        {
            var realEstate = await _context.RealEstates.FindAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            _context.RealEstates.Remove(realEstate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RealEstateExists(int id)
        {
            return _context.RealEstates.Any(e => e.ide == id);
        }


    }
}
