using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public string MenuCategoryName { get; set; }
        public int TotalDishes { get; set; }
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
