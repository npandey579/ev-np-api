using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azureauth.Models
{
    public class VendorModel
    {
        public VendorModel()
        {
            ProductLookupModel = new List<ProductLookupModel>();
            VehicleLookupModel = new List<VehicleLookupModel>();
        }

        public long VendorId { get; set; }

        public string VendorName { get; set; }

        public string MoblieContact { get; set; }
        public string TelephoneContact { get; set; }
        public string Address { get; set; }
        public string ServiceType { get; set; }

        public List<ProductLookupModel> ProductLookupModel { get; set; }
        public List<VehicleLookupModel> VehicleLookupModel { get; set; }
    }
    public class ProductLookupModel
    {

        public long ProductId { get; set; }

        public string ProductName { get; set; }
        public long? AvailableUnits { get; set; }
        public long? SoldUnits { get; set; }
        public decimal? Price { get; set; }
        public long VendorId { get; set; }


    }
    public partial class VehicleLookupModel
    {
        public long VehicleId { get; set; }

        public string VehicleName { get; set; }

        public string VehicleType { get; set; }

        public decimal BasePrice { get; set; }

        public decimal? PerDayPrice { get; set; }

        public decimal? PerKmPrice { get; set; }
        public decimal? DriverCharge { get; set; }

        public string Availablity { get; set; }
        public long VendorId { get; set; }


    }
}
