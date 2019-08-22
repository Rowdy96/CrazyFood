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
    public class MenuCategoriesController :ControllerBase
    {
        #region Private Variables

        #region Dependencies
        private IUnitOfWork _unitOfWork;

        #endregion

        #endregion

        #region Controllers
        public MenuCategoriesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        [HttpGet("{restaurantId}")]
        public async Task<IEnumerable<MenuCategory>> GetMenuCategories([FromRoute]int restaurantId)
        {
            return await _unitOfWork.MenuCategoryRepository.GetMenuCategories(restaurantId);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory([FromRoute] int categoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuCategory = await _unitOfWork.MenuCategoryRepository.GetMenuCategory(categoryId);

            if (menuCategory == null)
            {
                return NotFound();
            }

            return Ok(menuCategory);
        }

        [HttpPost("{restaurantId}")]
        public async Task<IActionResult> CreateMenuCategory([FromBody] MenuCategory menuCategory ,[FromRoute] int restaurantId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            menuCategory.RestaurantId = restaurantId;
            await _unitOfWork.MenuCategoryRepository.CreateMenuCategory(menuCategory);
            await _unitOfWork.Save();

            return Ok(menuCategory);
        }

        [HttpPut("{menuCategoryID}")]
        public async Task<IActionResult> EditMenuCategory([FromBody] MenuCategory menuCategory,
                                                          [FromRoute] int menuCategoryID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(menuCategory.Id == menuCategoryID)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.MenuCategoryRepository.UpdateMenuCategory(menuCategory);
                await _unitOfWork.Save();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!MenuCategoryExist(menuCategoryID))
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

       
        [HttpDelete("{menuCategoryID}")]
        public async Task<IActionResult> DeleteMenuCategory([FromRoute]int menuCategoryID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuCategory = await _unitOfWork.MenuCategoryRepository.GetMenuCategory(menuCategoryID);

            if(menuCategory == null)
            {
                return NotFound();
            }

            await _unitOfWork.MenuCategoryRepository.DeleteMenuCategory(menuCategoryID);
            await _unitOfWork.Save();

            return Ok(menuCategory);
        }
        #endregion

        #region Private Variables
        private bool MenuCategoryExist(int menuCategoryID)
        {
            if (_unitOfWork.MenuCategoryRepository.GetMenuCategory(menuCategoryID) == null)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
