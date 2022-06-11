using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model.Context;
using GeekShopping.IdentityServer.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly SqlContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(SqlContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initializer()
        {
            if (_roleManager.FindByNameAsync(IdentityConfiguration.Admin).Result != null)
                return;

            _roleManager.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "carlos-admin",
                Email = "carlos.admin@erudio.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (16) 12345-6789",
                FirstName = "Carlos",
                LastName = "Admin"
            };

            _userManager.CreateAsync(admin,"Patolino123$").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _userManager.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,$"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName,admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName,admin.LastName),
                new Claim(JwtClaimTypes.Role,IdentityConfiguration.Admin)
            }).Result;

            ApplicationUser client = new ApplicationUser()
            {
                UserName = "carlos-client",
                Email = "carlos.client@erudio.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (16) 12345-6788",
                FirstName = "Carlos",
                LastName = "Client"
            };

            _userManager.CreateAsync(client, "Patolino123$").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            var clientClaims = _userManager.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,$"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName,client.FirstName),
                new Claim(JwtClaimTypes.FamilyName,client.LastName),
                new Claim(JwtClaimTypes.Role,IdentityConfiguration.Client)
            }).Result;
        }
    }
}
