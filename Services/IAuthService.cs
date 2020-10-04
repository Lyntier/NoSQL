using NoSQL.Models;

namespace NoSQL.Services
{
    public interface IAuthService
    {
        User Login(string emailAddress, string password);

        bool Register(User user);
    }
}