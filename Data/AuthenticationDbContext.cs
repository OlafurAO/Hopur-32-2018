using BookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options) {}

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}