using System;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Web.DummyData
{
    public class DbSeeder
    {
        private readonly BaseContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public DbSeeder(BaseContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            // Create the Db if it doesn’t exist
            _dbContext.Database.EnsureCreated();
            // Create default Users
            if (await _dbContext.Users.CountAsync() == 0) await CreateUsersAsync();
        }

        private async Task CreateUsersAsync()
        {
            // local variables
            DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;
            string role_Administrators = "Administrators";
            string role_Registered = "Registered";

            //Create Roles (if they doesn't exist yet)
            if (!await _roleManager.RoleExistsAsync(role_Administrators)) await _roleManager.CreateAsync(new IdentityRole(role_Administrators));
            if (!await _roleManager.RoleExistsAsync(role_Registered)) await _roleManager.CreateAsync(new IdentityRole(role_Registered));

            // Create the "Admin" ApplicationUser account (if it doesn't exist already)
            var userAdmin = new AppUser
            {
                UserName = "admin",
                Email = "admin@opengamelist.com"
            };

            // Insert "Admin" into the Database and also assign the "Administrator" role to him.
            if (await _userManager.FindByIdAsync(userAdmin.Id) == null)
            {
                await _userManager.CreateAsync(userAdmin, "admin");
                //await _userManager.AddToRoleAsync(userAdmin, role_Administrators);
                // Remove Lockout and E-Mail confirmation.
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = false;
            }
            
            await _dbContext.SaveChangesAsync();
        }
        
    }
}
