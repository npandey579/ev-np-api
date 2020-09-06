using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using azureauth.Entities;
using azureauth.Models;
using azureauth.Models.Users;

namespace azureauth.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<VendorModel, Vendor>();
            CreateMap<ProductLookupModel, ProductLookup>();
            CreateMap<VehicleLookupModel, VehicleLookup>();
        }
    }
}
