using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class OrderAC
    {
        public Order Order { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
