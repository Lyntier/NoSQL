using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Identity;
using NoSQL.DataAccess;
using NoSQL.Models;

namespace NoSQL.Services
{
    public class LoginService : ILoginService
    {
        private IRepository<User> _userRepository;
        private IRepository<ResetPassword> _resetPasswordRepository;


        public LoginService(IRepository<User> userRepository,IRepository<ResetPassword> resetPasswordRepository)
        {
            _userRepository = userRepository;
            _resetPasswordRepository = resetPasswordRepository;
        }

        public bool Login(string emailAddress, string password, out User user)
        {
            user = _userRepository.FindOne(u =>
                u.EmailAddress.Equals(emailAddress) &&
                u.Password.Equals(password)
            );

            return user; // implicit true if not null
        }

        public void SaveToken(string token, string email)
        {
            _resetPasswordRepository.Add(new ResetPassword { ReturnToken = token, Email = email });
        }

        public void ResetPassword(string token,string password)
        {
            var userMail = _resetPasswordRepository.FindOne(x => x.ReturnToken.Equals(token));
            if (userMail)
            {
                var user = _userRepository.FindOne(x => x.EmailAddress.Equals(userMail.Email));
                user.Password = password;
                _userRepository.Update(user);
                _resetPasswordRepository.Delete(userMail);
            }
        }
    }
}
