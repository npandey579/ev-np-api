using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using azureauth.Entities;
using azureauth.Helpers;
using azureauth.Services;
using AutoMapper;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using azureauth.Models;

namespace azureauth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private IVendorService _vendorService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public VendorsController(IVendorService vendorService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _vendorService = vendorService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorModel>>> GetVendors()
        {
            try
            {
                var vendors = await _vendorService.GetVendors();
                return Ok(vendors);

            }

            catch (Exception ex){

            }
            return null;
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorModel>> GetVendor(long id)
        {
            var vendor = await _vendorService.GetVendors();

            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor.Where(s=>s.VendorId==id));
        }

        // PUT: api/Vendors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(long id, Vendor vendor)
        {
            if (id != vendor.VendorId)
            {
                return BadRequest();
            }           

            try
            {
                await _vendorService.PutVendor(id,vendor);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Vendors
        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor vendor)
        {
            await _vendorService.PostVendor(vendor);

            return CreatedAtAction("GetVendor", new { id = vendor.VendorId }, vendor);
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vendor>> DeleteVendor(long id)
        {
            await _vendorService.DeleteVendor(id);

            return Ok(id);
        }

    }
}
