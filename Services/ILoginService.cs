using System;
using System.Collections.Generic;
using System.Text;
using NoSQL.Models;

namespace NoSQL.Services
{
    public interface ILoginService
    {
        bool Login(string emailAddress, string password, out User user);

        void SaveToken(string token, string email);
        void ResetPassword(string token, string password);
    }
}
