using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azureauth.Models
{
    public class AuthToken
    {
        public string Token { get; set; }
        public string Username { get; set; }

        public AuthToken()
        {

        }

        public AuthToken(string token, string username)
        {
            this.Token = token;
            this.Username = username;
        }

        public AuthToken(string token)
        {
            this.Token = token;
        }

        
    }
}
