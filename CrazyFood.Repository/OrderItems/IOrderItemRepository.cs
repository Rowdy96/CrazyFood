using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.OrderItems
{
    public interface IOrderItemRepository
    {
        #region Methods
        Task<IEnumerable<OrderItem>> GetAllOrderItemOfOrder(int orderId);
        Task AddItemToOrder(int orderId, OrderItem orderItem);
        #endregion
    }
}
