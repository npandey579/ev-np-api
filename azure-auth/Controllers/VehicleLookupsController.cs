using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using azureauth.Entities;

namespace azureauth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleLookupsController : ControllerBase
    {
        private readonly MgsmasterdbContext _context;

        public VehicleLookupsController(MgsmasterdbContext context)
        {
            _context = context;
        }

        // GET: api/VehicleLookups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleLookup>>> GetVehicleLookups()
        {
            return await _context.VehicleLookups.ToListAsync();
        }

        // GET: api/VehicleLookups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleLookup>> GetVehicleLookup(long id)
        {
            var vehicleLookup = await _context.VehicleLookups.FindAsync(id);

            if (vehicleLookup == null)
            {
                return NotFound();
            }

            return vehicleLookup;
        }

        // PUT: api/VehicleLookups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleLookup(long id, VehicleLookup vehicleLookup)
        {
            if (id != vehicleLookup.VehicleId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleLookup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleLookupExists(id))
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

        // POST: api/VehicleLookups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VehicleLookup>> PostVehicleLookup(VehicleLookup vehicleLookup)
        {
            _context.VehicleLookups.Add(vehicleLookup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleLookup", new { id = vehicleLookup.VehicleId }, vehicleLookup);
        }

        // DELETE: api/VehicleLookups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleLookup>> DeleteVehicleLookup(long id)
        {
            var vehicleLookup = await _context.VehicleLookups.FindAsync(id);
            if (vehicleLookup == null)
            {
                return NotFound();
            }

            _context.VehicleLookups.Remove(vehicleLookup);
            await _context.SaveChangesAsync();

            return vehicleLookup;
        }

        private bool VehicleLookupExists(long id)
        {
            return _context.VehicleLookups.Any(e => e.VehicleId == id);
        }
    }
}
