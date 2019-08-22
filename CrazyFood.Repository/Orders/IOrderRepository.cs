using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Orders
{
    public interface IOrderRepository 
    {
        #region methods
        Task<IEnumerable<Order>> GetAllOrderOfRestaurant(int restaurantId);
        Task<IEnumerable<Order>> GetAllOrderOfUser(int userId);
        Task<IEnumerable<Order>> GetAllOrderOfDeliveryBoy(int deliveryBoyId);
        Task<Order> GetOrderById(int? orderId);
        Task AddOrder(int userId , int restaurantId, Order order);
        int TotalPriceOfOrder(int orderId);
        #endregion
    }
}
