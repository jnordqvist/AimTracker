using DSU22_Team4.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DSU22_Team4.Controllers
{
    public class AccountController : Controller
    {
        #region privatefields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        #endregion
        #region ctor
        public AccountController(RoleManager<IdentityRole> roleManager, 
                                 SignInManager<IdentityUser> signInManager, 
                                 UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        #region Login/Logout
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                   
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Login failed");
            }
            return View(model);
        }
        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Id = model.IbuId,                                     
                };

                var firstName = new Claim("FirstName", model.FirstName);
                var lastName = new Claim("LastName", model.LastName);
                var fullName = new Claim("FullName", $"{model.FirstName} {model.LastName}");
                
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (model.IsCoach == true)
                    {
                        var role = new IdentityRole("Coach");
                        var roleExists = await _roleManager.RoleExistsAsync("Coach");
                        if (!roleExists)
                        {
                            var createRole = await _roleManager.CreateAsync(role);
                        }

                        await _userManager.AddToRoleAsync(user, "Coach");
                    }
                    if (model.IsAthlete == true)
                    {
                        var role = new IdentityRole("Athlete");
                        var roleExists = await _roleManager.RoleExistsAsync("Athlete");
                        if (!roleExists)
                        {
                            var createRole = await _roleManager.CreateAsync(role);
                        }

                        await _userManager.AddToRoleAsync(user, "Athlete");
                    }
                    await _userManager.AddClaimAsync(user, firstName);
                    await _userManager.AddClaimAsync(user, lastName);
                    await _userManager.AddClaimAsync(user, fullName);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", "Something went wrong");
                }
            }
            return View(model);
        }
        #endregion
    }
}
