using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
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
    public class MenusController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public MenusController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //api/Menus/MenuList/1
        [HttpGet("{id}")]
        public async Task<IEnumerable<MenuAC>> MenuList([FromRoute] int id)
        {
            return await _unitOfWork.Menu.MenusOfRestaurant(id);
        }


        //api/Menus/MenuOfRestaurant/1
        [HttpGet("{menuId}")]

        public async Task<MenuAC> MenuOfRestaurant([FromRoute] int menuId)
        {
            return await _unitOfWork.Menu.GetMenu(menuId);
        }

        [HttpPost("{restaurantId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMenuCategory([FromRoute] int restaurantId
                                                            , [FromBody] MenuCategory menuCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _unitOfWork.Menu.CreateMenu(restaurantId, menuCategory);
            await _unitOfWork.Save();
            return Ok(menuCategory);
        }

        [HttpPut("{menuId}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateMenuCategory([FromRoute] int menuId
                                                            , [FromBody] MenuCategory menuCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (menuId != menuCategory.Id)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.Menu.UpdateMenu(menuCategory);
                await _unitOfWork.Save();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(menuId))
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

        private bool MenuExists(int menuId)
        {
            if (_unitOfWork.Menu.GetMenu(menuId) != null)
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
