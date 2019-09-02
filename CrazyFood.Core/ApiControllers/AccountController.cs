using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Core.ApiControllers
{
    //[Route("api/[controller]")]
    public class AccountController : Controller
    {
       
        private UserManager<Users> _userManager { get; set; }
        private SignInManager<Users> _signInManager { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; set; }

        public AccountController(UserManager<Users> userManager,
                                 SignInManager<Users> signInManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        //api/Account
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

   
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterAC model)
        {
            if (ModelState.IsValid)
            {
                var user = new Users { UserName = model.Name,
                                       Email = model.Email,
                                       PhoneNumber=model.Phone,
                                       Address=model.Address};
                var result = await _userManager.CreateAsync(user, model.Password);
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


        //[Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        
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
                    return View("Index");
                }

                ModelState.AddModelError("", "Invalid Login Attempt");

            }

            return View(model);

        }

        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Register", "Account");
        }


        //api/Account/id
        [Route("GetUserById")]
        [HttpGet("{userId}")]
        public async Task<Users> GetUserById([FromRoute]string userId)
        {
            Users user =await _userManager.FindByIdAsync(userId);
            return user;
        }

        [Route("EditUser")]
        [HttpPut]
        [Authorize]
        public async Task EditUser([FromBody]Users user)
        {
            await _userManager.UpdateAsync(user);
        }

    }
}
