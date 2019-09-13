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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DishsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public DishsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //api/Dishs/GetDishesOfMenu/1
        [HttpGet("{menuId}")]
        public async Task<IEnumerable<Dish>> GetDishesOfMenu([FromRoute]int menuId)
        {
            return await _unitOfWork.Dish.GetAllDishOfMenu(menuId);
        }

        //api/Dishs/GetDish/1
        [HttpGet("{dishId}")]
        public async Task<Dish> GetDish([FromRoute]int dishId)
        {
            return await _unitOfWork.Dish.GetDish(dishId);
        }

        //api/Dishs/CreateDish/1
        [HttpPost("{menuId}")]
        public async Task<IActionResult> CreateDish([FromRoute]int menuId, [FromBody] Dish dish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _unitOfWork.Dish.CreateDish(menuId, dish);
            await _unitOfWork.Save();
            return Ok(dish);
        }

        //api/Dishs/UpdateDish/5
        [HttpPut("{dishID}")]
        public async Task<IActionResult> UpdateDish([FromRoute] int dishID
                                                          , [FromBody] Dish dish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dishID != dish.Id)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.Dish.UpdateDish(dish);
                await _unitOfWork.Save();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(dishID))
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

        //api/Dishs/DeleteDish/5
        [HttpDelete("{dishId}")]
        public async Task<IActionResult> DeleteDish([FromRoute] int dishId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dish = await _unitOfWork.Dish.GetDish(dishId);
            if (dish == null)
            {
                return NotFound();
            }

            await _unitOfWork.Dish.DeleteDish(dishId);
            await _unitOfWork.Save();

            return Ok(dish);
        }

        private bool DishExists(int dishId)
        {

            if (_unitOfWork.Dish.GetDish(dishId) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
