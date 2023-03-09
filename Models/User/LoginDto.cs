using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models.User
{
    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
