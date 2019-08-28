using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class MenuAC
    {
        public string MenuCategoryName { get; set; }
        public ICollection<DishAC> Dishes { get; set; }
    }
}
