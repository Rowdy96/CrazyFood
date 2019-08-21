using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;

namespace CrazyFood.Repository.Reviews
{
    public class ReviewRepository : IReviewRepository
    {
        public Task AddReview(Review review)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDish(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetAllReviewsOfRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetAllReviewsOfUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetReviewById(int? reviewId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDish(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
