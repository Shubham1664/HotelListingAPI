using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace HotelListing.Models.User
{
    public class ApiUserDto : LoginDto
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        
    }
}
