using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Cuisine
    {
        #region Public Propertry
        public int Id { get; set; }
        public string CuisineType { get; set; }

        #region Navigation Propertry
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        #endregion
        #endregion
    }
}
