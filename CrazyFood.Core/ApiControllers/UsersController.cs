using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Core.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private SignInManager<Users> _signInManager;
        private UserManager<Users> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IUnitOfWork _unitOfWork;
        public UsersController(SignInManager<Users> signInManager
                              , UserManager<Users> userManager
                              , RoleManager<IdentityRole> roleManager
                              , IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        //api/Users/GetLoggedInUSer
        [HttpGet]
        public async Task<IActionResult> GetLoggedInUSer()
        {

            var username = User.Identity.Name;
            if (username == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Users user = await _userManager.FindByNameAsync(username);
                var userRoles = await _userManager.GetRolesAsync(user);
                UserAC userAC = _unitOfWork.UserRepository.GetUser(user);
                userAC.Roles = userRoles;
                return Ok(userAC);
            }
        }

        

        //api/Users/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        //api/Users/GetUserDetails
        [HttpGet("{userId}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> GetUserDetails(string userId)
        {
            Users user = await _userManager.FindByIdAsync(userId);
           
            
            if (user == null)
            {
                return NoContent();
            }

            UserAC userAC = _unitOfWork.UserRepository.GetUser(user);
            return Ok(userAC);
        }
    }
}
