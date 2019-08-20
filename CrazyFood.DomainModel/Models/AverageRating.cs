using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class AverageRating
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int AverageUserRating { get; set; }
        public string RatingText { get; set; }
        public int Votes { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
