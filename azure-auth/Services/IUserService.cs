using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using azureauth.Entities;
using azureauth.Models.Users;

namespace azureauth.Services

{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(long id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(long id);
    }
}
