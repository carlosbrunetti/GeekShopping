using GeekShopping.IdentityServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class SqlContext : IdentityDbContext<ApplicationUser>
    {
        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options) { }
    }
}
