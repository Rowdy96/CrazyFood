using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class OrderItem
    {
        #region Public Propertry
        public int Id { get; set; }
        public int ItemCount { get; set; }

        #region Navigation Propertry
        public int OrderId { get; set; }
        public int DishId { get; set; }
       // public Order Order { get; set; }
        public Dish Dish { get; set; }
        #endregion
        #endregion
    }
}
