using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class MenuCategory
    {
        #region Public Propertry
        public int Id { get; set; }
        public string MenuCategoryName { get; set; }
        public int TotalDishes { get; set; }

        #region Navigation Propertry
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        #endregion
        #endregion
    }
}
