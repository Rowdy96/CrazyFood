using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Core.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestaurantsController:ControllerBase
    {
        #region Private Variables
        #region Dependencies
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<Users> _userManager { get; set; }
        private SignInManager<Users> _signInManager { get; set; }
        #endregion
        #endregion

        #region Constructors
        public RestaurantsController(IUnitOfWork unitOfWork,
                                     UserManager<Users> userManager,
                                     SignInManager<Users> signInManager)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        #endregion

        #region Private Methods
        private bool RestaurantExists(int restaurantID)
        {

            if (_unitOfWork.restaurant.GetRestaurantById(restaurantID) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region Public Methods
        //api/Restaurants/GetAll
        [HttpGet]
        public async Task<IEnumerable<RestaurantAC>> GetAll()
        {
            return await _unitOfWork
                        .restaurant
                        .Restaurants();
        }

        //api/Restaurants/RestaurantsOfCity/1
        [HttpGet("{cityId}")]
        public async Task<IEnumerable<RestaurantAC>> RestaurantsOfCity([FromRoute] int cityId)
        {
            return await _unitOfWork
                        .restaurant
                        .GetRestaurantsOfACity(cityId);
        }

        //api/Restaurants/GetRestaurant/1
        [HttpGet("{restaurantId}")]
        public async Task<RestaurantAC> GetRestaurant([FromRoute] int restaurantId)
        {
            return await _unitOfWork
                        .restaurant
                        .GetRestaurantById(restaurantId);
        }

        //api/Restaurants/CreateRestaurant
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _unitOfWork.restaurant.CreateRestaurant(restaurant);
            await _unitOfWork.Save();
            return Ok(restaurant);
        }

        //api/Restaurants/UpdateRestaurant/5
        [HttpPut("{restaurantID}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int restaurantID
                                                          ,[FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (restaurantID != restaurant.Id)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.restaurant.UpadateRestaurant(restaurant);
                await _unitOfWork.Save();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(restaurantID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //api/Restaurants/DeleteRestaurant/5
        [HttpDelete("{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int restaurantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Restaurant = await _unitOfWork.restaurant.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return NotFound();
            }

            await _unitOfWork.restaurant.DeleteRestaurant(restaurantId);
            await _unitOfWork.Save();

            return Ok(Restaurant);
        }

        //api/Restaurants/GetCurrentUser
        [HttpGet]
        public async Task<Users> GetCurrentUser()
        {
            var username = User.Identity.Name;
            Users user = await _userManager.FindByNameAsync(username);
            return user;
        }

        #endregion

    }
}
