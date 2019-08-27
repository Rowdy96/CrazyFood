using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Core.ApiControllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private UserManager<Users> _userManager { get; set; }
        private SignInManager<Users> _signInManager { get; set; }

        public AccountController(UserManager<Users> userManager,
                                 SignInManager<Users> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        //api/Account
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

   
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAC model)
        {
            if (ModelState.IsValid)
            {
                var user = new Users { UserName = model.Email, Email = model.Email };
                var result = await this._userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
            
        }


        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginAC model)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email,
                                                                      model.Password
                                                                      ,model.RememberMe
                                                                      ,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Register","Account");
                }


                ModelState.AddModelError("", "Invalid Login Attempt");

            }

            return View(model);

        }

        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> Logout(LoginAC model)
        {

        
                 await _signInManager.SignOutAsync();
            return RedirectToAction("Register", "Account");

        }

    }
}
