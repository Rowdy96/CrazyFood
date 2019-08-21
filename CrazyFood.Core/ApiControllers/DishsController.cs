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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DishsController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DishsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("{menuCategoryId}")]
        public async Task<IEnumerable<Dish>> GetDishesOfMenu([FromRoute]int menuCategoryId)
        {
            return await _unitOfWork.DishRepository.GetAllDishes(menuCategoryId);
        }

        [HttpGet("dishId")]
        public async Task<IActionResult> GetDishById([FromRoute] int dishId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Dish = await _unitOfWork.DishRepository.GetDishById(dishId);
            if(Dish == null)
            {
                return NotFound();
            }

            return Ok(Dish);
        }

        [HttpPost("{menuCategoryId}")]
        public async Task<IActionResult> AddDish([FromRoute]int menuCategoryId, [FromBody] Dish dish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dish.MenuCategoryId = menuCategoryId;
            await _unitOfWork.DishRepository.CreateDish(dish);
            await _unitOfWork.Save();

            return Ok(dish);
        }

        [HttpPut("{dishId}")]
        public async Task<IActionResult> EditDish ([FromRoute] int dishId, [FromBody] Dish dish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dishId != dish.Id)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.DishRepository.UpdateDish(dish);
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(dishId))
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

        [HttpDelete("{dishId}")]
        public async Task<IActionResult> DeleteDish([FromRoute] int dishId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Dish = await _unitOfWork.DishRepository.GetDishById(dishId);
            if (Dish == null)
            {
                return NotFound();
            }

            await _unitOfWork.DishRepository.DeleteDish(dishId);
            await _unitOfWork.Save();

            return Ok(Dish);
        }

        private bool DishExists(int id)
        {
            if (_unitOfWork.DishRepository.GetDishById(id) == null)
            {
                return false;
            }

            return true;
        }
    }
}
