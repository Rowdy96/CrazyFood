using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class AverageRating
    {
        #region public propertry
        public int Id { get; set; }
        public int AverageUserRating { get; set; }
        public string RatingText { get; set; }
        public int Votes { get; set; }

        #region navigation propertry
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        #endregion
        #endregion
    }
}
