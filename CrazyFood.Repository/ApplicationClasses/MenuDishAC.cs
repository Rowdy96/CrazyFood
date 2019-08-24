using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class MenuDishAC
    {
        public MenuCategory MenuCategory { get; set; }
        public ICollection<Dish> Dishes { get; set; } 
    }
}
