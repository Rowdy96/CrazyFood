using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Review
    {
        #region Public Propertry
        public int Id { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public int Likes { get; set; }

        #region Navigation Propertry
        public string UserId { get; set; }
        public int RestaurantId { get; set; }

        public Users User { get; set; }
        public Restaurant Restaurant { get; set; }

        #endregion
        #endregion
    }
}
