using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Reviews

{
    public interface IReviewRepository
    {
        Task<IEnumerable<ReviewAC>> GetAllReviewOfRestaurant(int restaurantId);
        Task<IEnumerable<ReviewAC>> GetAllReviewOfUser(string userId);
        Task AddReview( ReviewAC review);
        Task AddReviewComment(int reviewId, ReviewAC reviewComment);
        Task AddLike(int reviewId, ReviewAC reviewLike);
        Task AddRating(int restaurantId, ReviewAC review);
        void UpdateReview(Review review);
        Task<ReviewComment> GetComment(int commentId);
        Task<ReviewAC> GetReview(int reviewId);
        Task AverageRatingOfResaturant(int restaurantId);
    }
}
