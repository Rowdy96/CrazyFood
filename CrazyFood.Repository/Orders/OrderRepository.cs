using CrazyFood.DomainModel.Data;
using CrazyFood.Repository.ApplicationClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CrazyFoodContext _context;
        public List<OrderOfUserAC> OrdersOfUser = new List<OrderOfUserAC>();
        
        public OrderRepository(CrazyFoodContext context)
        {
            this._context = context;
        }

        public async Task AddOrder(OrderAC order)
        {
            await _context.Order.AddAsync(order.Order);

            foreach(var item in order.OrderItem)
            {
                item.Order = order.Order;
            }

            await _context.OrderItem.AddRangeAsync(order.OrderItem);
        }

        public  Task<IEnumerable<OrderAC>> GetAllOrderOfRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderOfUserAC>> GetAllOrderOfUser(string userId)
        {
            var orders = await _context
                             .Order
                             .Include(or => or.User)
                             .Where(or => or.UserId == userId)
                             .ToListAsync();

            
            foreach (var order in orders)
            {
                List<OrderItemAC> OrderItemACs = new List<OrderItemAC>();
                OrderOfUserAC orderOfUserAC = new OrderOfUserAC();

                orderOfUserAC.OrderId = order.Id;
                orderOfUserAC.UserId = userId;
                var OrderItems =await _context
                                         .OrderItem
                                         .Include(ot => ot.Dish)
                                         .ThenInclude(d => d.MenuCategory)
                                         .ThenInclude(mc => mc.Restaurant)
                                         .Where(ot => ot.OrderId == order.Id)
                                         .ToListAsync();
                
                foreach(var item in OrderItems)
                {
                    OrderItemACs.Add(new OrderItemAC {
                       Id = item.Id,
                       DishId = item.DishId,
                       DishName = item.Dish.DishName,
                       Price = item.Dish.Price,
                       ItemCount = item.ItemCount,
                       MenuCategoryId = item.Dish.MenuCategoryId,
                       MenuCategoryName = item.Dish.MenuCategory.MenuCategoryName
                    });

                    orderOfUserAC.RestaurantId = item.Dish.MenuCategory.RestaurantId;
                    orderOfUserAC.RestaurantName = item.Dish.MenuCategory.Restaurant.Name;
                }

                orderOfUserAC.OrderItem = OrderItemACs;
                OrdersOfUser.Add(orderOfUserAC);

            }

            return OrdersOfUser;
        }

        public async Task<OrderAC> GetAOder(int orderId)
        {
            var order = await _context
                             .Order
                             .FindAsync(orderId);
            OrderAC orderAC = new OrderAC();
            orderAC.Order = order;
            orderAC.OrderItem = await _context
                                     .OrderItem
                                     .Where(ot => ot.OrderId == order.Id)
                                     .ToListAsync();
            return orderAC;
        }
    }
}
