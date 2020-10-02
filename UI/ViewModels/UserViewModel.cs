using System.ComponentModel.DataAnnotations;
using NoSQL.Models;

namespace NoSQL.UI.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        public UserViewModel(User user)
        {
        }

        public string EmailAddress { get; set; }

        [ScaffoldColumn(false)] public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserType Type { get; set; }

        public string PhoneNumber { get; set; }

        public UserLocation Location { get; set; }

        public static implicit operator User(UserViewModel uservm)
        {
            return new User
            {
                EmailAddress = uservm.EmailAddress,
                Password = uservm.Password,
                FirstName = uservm.FirstName,
                LastName = uservm.LastName,
                Type = uservm.Type,
                PhoneNumber = uservm.PhoneNumber,
                Location = uservm.Location
            };
        }
    }
}