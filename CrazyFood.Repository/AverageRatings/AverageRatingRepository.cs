using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;

namespace CrazyFood.Repository.AverageRatings
{
    public class AverageRatingRepository : IAverageRatingRepository
    {
        public int CalaculateAverageRating(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task<AverageRating> GetAverageRatingOfRestaurant(int? restaurantId)
        {
            throw new NotImplementedException();
        }
    }
}
