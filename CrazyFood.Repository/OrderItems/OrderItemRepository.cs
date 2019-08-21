using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;

namespace CrazyFood.Repository.OrderItems
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public Task AddItemToOrder(int orderId,OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderItem>> GetAllOrderItemOfOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
