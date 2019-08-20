using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }

        public Users User { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
