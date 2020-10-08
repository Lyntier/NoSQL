using NoSQL.DataAccess;
using NoSQL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSQL.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            _userRepository.Add(user);
        }

        public IEnumerable<User> ListUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
