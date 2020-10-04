using NoSQL.DataAccess;
using NoSQL.Models;

namespace NoSQL.Services
{
    using BCrypt.Net; // Needs to be inside namespace declaration, otherwise it's not recognized below.
    
    public class AuthService : IAuthService
    {
        private IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        
        public User Login(string emailAddress, string password)
        {
            return _userRepository.Find(user =>
                emailAddress.Equals(user.EmailAddress) 
                && BCrypt.Verify(password, user.Password) // Using bcrypt to store passwords.
                );
        }

        public bool Register(User user)
        {
            User existing = _userRepository.Find(dbUser => user.EmailAddress.Equals(dbUser.EmailAddress));
            if (existing)
            { 
                // Email is unique in application, so if the email exists in
              // the database, we don't want to register this user again.
                return false;
            } 
            
            
            
            _userRepository.Add(user);
            return true;
        }
    }
}