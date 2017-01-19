using System;
using System.Collections.Generic;
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
            //Add data to Db
            await AddDataToDatabase();
            // Create default Users
            if (await _dbContext.Users.CountAsync() == 0) await CreateUsersAsync();
        }

        private async Task CreateUsersAsync()
        {
            // local variables
            DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;
            string role_Administrators = "Administrators";

            //Create Roles (if they doesn't exist yet)
            if (!await _roleManager.RoleExistsAsync(role_Administrators)) await _roleManager.CreateAsync(new IdentityRole(role_Administrators));

            // Create the "Admin" ApplicationUser account (if it doesn't exist already)
            var userAdmin = new AppUser
            {
                UserName = "admin",
                Email = "admin@opengamelist.com"
            };

            // Insert "Admin" into the Database and also assign the "Administrator" role to him.
            if (await _userManager.FindByIdAsync(userAdmin.Id) == null)
            {
                var result = await _userManager.CreateAsync(userAdmin, "Admin00");
                await _userManager.AddToRoleAsync(userAdmin, role_Administrators);
                // Remove Lockout and E-Mail confirmation.
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = false;
            }
            
            await _dbContext.SaveChangesAsync();
        }

        private async Task AddDataToDatabase()
        {
            var studentRepository = new StudentRepository();
            studentRepository.DeleteAll();

            var teacherRepository = new TeacherRepository();
            teacherRepository.DeleteAll();

            var courseRepository = new CourseRepository();
            courseRepository.DeleteAll();

            var groupRepository = new GroupRepository();
            groupRepository.DeleteAll();

            var a5 = new Group("A5", 3);
            var a2 = new Group("A2", 2);

            var ionut = new Student("001", "Ionut", "Iacob", a5, DateTime.Now);
            var anca = new Student("002", "Anca", "Adascalitei", a5, DateTime.Now);
            var stefan = new Student("003", "Stefan", "Gordin", a5, DateTime.Now);
            var eve = new Student("004", "Eveline", "Giosanu", a5, DateTime.Now);
            var alexandra = new Student("005", "Alexandra", "Gadioi", a2, DateTime.Now);

            var florin = new Teacher("Florin", "Olariu", DateTime.Now);
            var dorel = new Teacher("Dorel", "Lucanu", DateTime.Now);
            var cosmin = new Teacher("Cosmin", "Varlan", DateTime.Now);

            studentRepository.Create(alexandra);

            courseRepository.Create(new Course("Introduction to .NET", 3, new List<Student> { ionut, anca },
                new List<Teacher> { florin }));
            courseRepository.Create(new Course("Proiectarea Algoritmilor", 1, new List<Student> { eve },
                new List<Teacher> { dorel }));
            courseRepository.Create(new Course("Baze de Date", 2, new List<Student> { stefan, ionut, eve },
                new List<Teacher> { cosmin }));
        }

    }
}
