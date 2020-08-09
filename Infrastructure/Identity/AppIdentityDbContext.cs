using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Identity
{

    // needs to add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    public class AppIdentityDbContext : IdentityDbContext<AppUser> // need to add <AppUser> to make entityframework add columns for its properties in database
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }


        // to avoid errors
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}