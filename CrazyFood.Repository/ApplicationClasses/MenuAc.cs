using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class MenuAC
    {
        public int Id { get; set; }
        public int TotalDishes { get; set; }
        public string MenuCategoryName { get; set; }
        public ICollection<DishAC> Dishes { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
    }
}
