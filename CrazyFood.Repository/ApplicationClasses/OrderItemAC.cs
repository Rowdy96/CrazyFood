using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class OrderItemAC
    {
        #region Public Propertry
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemCount { get; set; }
        public int DishId { get; set; }
        public string DishName { get; set; }
        public string Price { get; set; }
        public int MenuCategoryId { get; set; }
        public string MenuCategoryName { get; set; }
        #endregion
       
    }
}
