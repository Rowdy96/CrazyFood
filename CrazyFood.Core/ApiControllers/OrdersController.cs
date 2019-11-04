using CrazyFood.Repository.ApplicationClasses;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Core.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Private Variables
        private IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public OrdersController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        //api/Orders/GetAllOrdersOfUser/1002
        [HttpGet("{userId}")]
        //[Authorize(Roles = "Admin, Customer")]
        public async Task<IEnumerable<OrderOfUserAC>> GetAllOrdersOfUser([FromRoute]string userId)
        {
            return await _unitOfWork.OrderRepository.GetAllOrderOfUser(userId);
        }

        //api/Orders/AddOrder
        [HttpPost]
       // [Authorize(Roles = "Admin, Customer")]
        public async Task<IActionResult> AddOrder([FromBody] OrderAC order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _unitOfWork.OrderRepository.AddOrder(order);
            await _unitOfWork.Save();
            return Ok(order);
        }
        #endregion
    }
}
