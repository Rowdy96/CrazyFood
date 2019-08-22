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
    public class UsersController : ControllerBase
    {
        #region Private Variables
        
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public UsersController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Mrthods
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _unitOfWork.UserRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.UserRepository.CreateUser(user);
            await _unitOfWork.Save();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser([FromRoute] int id, [FromBody] Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.UserRepository.UpdateUser(user);
                await _unitOfWork.Save();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _unitOfWork.UserRepository.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }

            await _unitOfWork.UserRepository.DeleteUser(id);
            await _unitOfWork.Save();

            return Ok(User);
        }
        #endregion

        #region Private Methods
        private bool UserExists(int id)
        {
            if (_unitOfWork.UserRepository.GetUserById(id) != null)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
