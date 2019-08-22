using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        #region Private Variables

        #region Dependencies
        private IUnitOfWork _unitOfWork;
        #endregion

        #endregion

        #region Constructor
        public RestaurantsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        // GET: api/Restaurant
        [HttpGet]
        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            var tests = _unitOfWork.RestaurantRepository.GetAllRestaurants();
            return await tests;
        }

        // GET: api/Restaurant/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = await _unitOfWork.RestaurantRepository.GetRestaurantById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.RestaurantRepository.UpdateRestaurant(restaurant);
                await _unitOfWork.Save();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST: api/Restaurant
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.RestaurantRepository.CreateRestaurant(restaurant);
            await _unitOfWork.Save();
            return CreatedAtAction("GetAllRestaurants", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Restaurant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = await _unitOfWork.RestaurantRepository.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            await _unitOfWork.RestaurantRepository.DeleteRestaurant(id);
            await _unitOfWork.Save();

            return Ok(restaurant);
        }
        #endregion

        #region Private Methods
        private bool RestaurantExists(int id)
        {
            if (_unitOfWork.RestaurantRepository.GetRestaurantById(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
