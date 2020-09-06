using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using azureauth.Entities;
using azureauth.Models.Users;

namespace azureauth.Services

{
    public interface IVendorService
    {
         Task<IEnumerable<Vendor>> GetVendors();
        Task<Vendor> GetVendor(long id);
        Task PutVendor(long id, Vendor vendor);
        Task<Vendor> PostVendor(Vendor vendor);
        Task<Vendor> DeleteVendor(long id);
    }
}
