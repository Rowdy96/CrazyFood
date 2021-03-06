﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Dish
    {
        #region Public Propertry
        public int Id { get; set; }
        public string DishName { get; set; }
        public string Price { get; set; }
        public bool IsDeleted { get; set; }

        #region Navigation Propertry
        public int MenuCategoryId { get; set; }
        public MenuCategory MenuCategory { get; set; }
        #endregion
        #endregion
    }
}
