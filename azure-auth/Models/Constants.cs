using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azureauth.Models
{
    public class Constants
    {
        public static readonly long ACCESS_TOKEN_VALIDITY_SECONDS = 5 * 60 * 60;
        public static readonly string SIGNING_KEY = "devglan123r";
        public static readonly string TOKEN_PREFIX = "Bearer ";
        public static readonly string HEADER_STRING = "Authorization";
    }
}
