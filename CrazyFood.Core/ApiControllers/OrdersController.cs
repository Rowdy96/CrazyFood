using CrazyFood.Repository.ApplicationClasses;
using CrazyFood.Repository.UnitOfWork;
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
        private IUnitOfWork _unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //api/Orders/GetAllOrdersOfUser/1002
        [HttpGet("{userId}")]
        public async Task<IEnumerable<OrderAC>> GetAllOrdersOfUser([FromRoute]string userId)
        {
            return await _unitOfWork.OrderRepository.GetAllOrderOfUser(userId);
        }

        [HttpPost]
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
    }
}
