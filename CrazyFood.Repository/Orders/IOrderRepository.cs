using CrazyFood.Repository.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Orders
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderAC>> GetAllOrderOfRestaurant(int restaurantId);
        Task<IEnumerable<OrderOfUserAC>> GetAllOrderOfUser(string userId);
        Task<OrderAC> GetAOder(int orderId);
        Task AddOrder(OrderAC order);
    }
}
