using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using azureauth.Entities;
using azureauth.Helpers;
using azureauth.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace azureauth.Services
{
    public class VendorService:IVendorService
    {
        private MgsmasterdbContext _context;
        private readonly AppSettings _appSettings;

        public VendorService(MgsmasterdbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<Vendor>> GetVendors()
        {
            return await _context.Vendors.Include(p=>p.VehicleLookups).Include(v=>v.ProductLookups).ToListAsync();

        }
        public async Task<Vendor> GetVendor(long id)
        {
            var vendor = await _context.Vendors.FindAsync(id);

            if (vendor == null)
            {
                return null;
            }

            return vendor;
        }


        public async Task PutVendor(long id, Vendor vendor)
        {
            if (id != vendor.VendorId)
            {
                return;
            }

            _context.Entry(vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }

            return;
        }

 
        public async Task<Vendor> PostVendor(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return vendor;
        }
        public async Task<Vendor> DeleteVendor(long id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return null;
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return vendor;
        }

        private bool VendorExists(long id)
        {
            return _context.Vendors.Any(e => e.VendorId == id);
        }
      
    }
}