using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using NoSQL.DataAccess;
using NoSQL.Models;

namespace NoSQL.Services
{
    public class LoginService : ILoginService
    {
        private IRepository<User> _userRepository;

        public LoginService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(string emailAddress, string password, out User user)
        {
            user = _userRepository.FindOne(u =>
                u.EmailAddress.Equals(emailAddress) &&
                u.Password.Equals(password)
            );

            return user; // implicit true if not null
        }
    }
}
