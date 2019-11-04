using CrazyFood.DomainModel.Models;
using System.Collections.Generic;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class OrderOfUserAC
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public List<OrderItemAC> OrderItem { get; set; }
    }
}
