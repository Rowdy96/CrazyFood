﻿using CrazyFood.DomainModel.Models;
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
    public class OrderItemsController : ControllerBase
    {
        #region Priavate Varibables
        #region Dependencies
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #endregion

        #region Controllers
        public OrderItemsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        [HttpGet("{orderId}")]
        public async Task<IEnumerable<OrderItem>> GetOrderItemsOfOrder([FromRoute] int orderId)
        {
            return await _unitOfWork.OrderItemRepository.GetAllOrderItemOfOrder(orderId);
        }

        [HttpPost("{orderId}")]
        public async Task<IActionResult> AddItemToOrder([FromRoute]int orderId,[FromBody]OrderItem orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _unitOfWork.OrderItemRepository.AddItemToOrder(orderId, orderItem);
            await _unitOfWork.Save();
            return Ok(orderItem);
        }
        #endregion
    }
}
