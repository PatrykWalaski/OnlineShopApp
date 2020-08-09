using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByClaimsPrincipleByEmailWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            // taking email from token
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value; 

            // getting user including address table by email we had saved in token
            return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        } 

        public static async Task<AppUser> FindByEmailFromClaimsPrincipal(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value; 
            
            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}