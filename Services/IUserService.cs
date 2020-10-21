using NoSQL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSQL.Services
{
    public interface IUserService
    {
        IEnumerable<User> ListUsers();

       
        void CreateUser(User user);

        User GetByEmail(string emailAddress);
    }
}
