using NoSQL.Models;

namespace NoSQL.Services
{
    public interface IAuthService
    {
        bool Login(string emailAddress, string password, out User user);
        User Register(User user);
    }
}