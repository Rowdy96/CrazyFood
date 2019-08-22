using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Reviews
{
    public interface IReviewRepository
    {
        #region Methods
        Task<IEnumerable<Review>> GetAllReviewsOfRestaurant(int restaurantId);
        Task<IEnumerable<Review>> GetAllReviewsOfUser(int userId);
        Task<Review> GetReviewById(int? reviewId);
        Task AddReview(Review review);
        Task UpdateDish(Review review);
        Task DeleteDish(int reviewId);
        #endregion
    }
}
