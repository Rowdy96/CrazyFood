using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;

namespace CrazyFood.Repository.Orders
{
    public class OrderRepository : IOrderRepository
    {
        public Task AddOrder(int userId, int restaurantId, Order order)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrderOfDeliveryBoy(int deliveryBoyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrderOfRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrderOfUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById(int? orderId)
        {
            throw new NotImplementedException();
        }

        public int TotalPriceOfOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
