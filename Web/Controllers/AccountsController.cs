using System;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api")]
    public class AccountsController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _loginManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountsController(UserManager<AppUser> userManager,
           SignInManager<AppUser> loginManager,
           RoleManager<AppRole> roleManager)
        {
            this._userManager = userManager;
            this._loginManager = loginManager;
            this._roleManager = roleManager;
        }

        [HttpGet("users", Name = "Users")]
        [AllowAnonymous]
        public IActionResult GetUsers()
        {
            return Ok(_userManager.GetUsersInRoleAsync("BaseUser"));
        }

        [HttpGet("register", Name = "RegisterGet")]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return Ok("Register");
        }

        [HttpPost("register", Name = "RegisterPost")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] AppUserDto registerUser)
        {
            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser();
                newUser.UserName = registerUser.UserName;
                newUser.Email = registerUser.Email;

                IdentityResult result = _userManager.CreateAsync(newUser, registerUser.Password).Result;

                //If user is created
                if (result.Succeeded)
                {
                    //If user doesn't have role
                    if (!_roleManager.RoleExistsAsync("BaseUser").Result)
                    {
                        AppRole role = new AppRole();
                        role.Name = "BaseUser";
                        role.Description = "Perform only get operations.";

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            return BadRequest("Error while creating role!");
                        }
                    }

                    _userManager.AddToRoleAsync(newUser,"BaseUser").Wait();
                    return RedirectToRoute("LoginGet");
                }
            }
            return NoContent();
        }

        [HttpGet("login", Name = "LoginGet")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return Ok("Login");
        }

    }
}