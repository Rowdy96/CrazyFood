using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CrazyFood.Core.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("{userId}/{restaurantId}")]
        public async Task<IActionResult> AddOrder([FromRoute]int userId,
                                          [FromRoute]int restaurantId,
                                          [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.OrderRepository.AddOrder(userId, restaurantId, order);
            await _unitOfWork.Save();

            return Ok(order);
        }
        
        [HttpGet("{restaurantId}")]
        public async Task<IEnumerable<Order>> GetOrdersOfRestaurant([FromRoute] int restaurantId)
        {
            return await _unitOfWork.OrderRepository.GetAllOrderOfRestaurant(restaurantId);
        }

        [HttpGet("{deliveryBoyId}")]
        public async Task<IEnumerable<Order>> GetOrdersOfdeliveryBoy([FromRoute] int deliveryBoyId)
        {
            return await _unitOfWork.OrderRepository.GetAllOrderOfDeliveryBoy(deliveryBoyId);
        }


        [HttpGet("{orderId}")]
        public async Task<Order> GetOrder([FromRoute] int orderId)
        {
            return await _unitOfWork.OrderRepository.GetOrderById(orderId);
        }
    }
}
