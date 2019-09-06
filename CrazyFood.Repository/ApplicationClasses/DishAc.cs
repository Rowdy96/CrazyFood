using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class DishAC
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public string DishPrice { get; set; }
        public int MenuCategoryId { get; set; }
    }
}
