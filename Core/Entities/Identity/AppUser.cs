using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    // need to add Microsoft.Extensions.Identity.Stores package
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}