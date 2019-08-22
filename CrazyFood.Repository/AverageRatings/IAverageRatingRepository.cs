using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.AverageRatings
{
    public interface IAverageRatingRepository
    {
        #region Methods
        Task<AverageRating> GetAverageRatingOfRestaurant(int? restaurantId);
        int CalaculateAverageRating(int restaurantId);
        #endregion
    }
}
