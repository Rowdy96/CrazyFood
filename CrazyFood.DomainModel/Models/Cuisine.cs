using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Cuisine
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string CuisineType { get; set; }

        public Restaurant Restaurant { get; set; }

    }
}
