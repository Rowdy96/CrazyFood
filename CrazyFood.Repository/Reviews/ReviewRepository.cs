using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Reviews
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CrazyFoodContext _context;

        public List<ReviewAC> AllReviews = new List<ReviewAC>();
        public List<ReviewAC> ReviewsOfUser = new List<ReviewAC>();

        public ReviewRepository(CrazyFoodContext context)
        {
            this._context = context;
        }

        public async Task AddLike(int reviewId, ReviewAC reviewLike)
        {
            reviewLike.Review = await _context.Review.FindAsync(reviewId);
            reviewLike.ReviewLike.ReviewId = reviewId;
            await _context.ReviewLike.AddAsync(reviewLike.ReviewLike);
            reviewLike.Review.Likes = reviewLike.Review.Likes + 1;
        }

        //private bool LikeExists(int reviewId, int userId)
        //{
        //    var = _context
        //         .ReviewLike
        //         .Where(l => l.UserId==userId)
                 
        //}

        public async Task AddRating(int restaurantId, ReviewAC reviewRating)
        {
            reviewRating.Review.RestaurantId = restaurantId;
            await _context.Review.AddAsync(reviewRating.Review);
        }

        public async Task AddReview(int restaurantId, ReviewAC review)
        {
            review.Review.RestaurantId = restaurantId;
            await _context.Review.AddAsync(review.Review);
        }

        public async Task AddReviewComment(int reviewId, ReviewAC reviewComment)
        {
            reviewComment.Comment.ReviewId = reviewId;
            await _context.ReviewComment.AddAsync(reviewComment.Comment);
        }

        public async Task<IEnumerable<ReviewAC>> GetAllReviewOfRestaurant(int restaurantId)
        {
            var reviews = await _context
                                .Review
                                .Include(r => r.Restaurant)
                                .ThenInclude(c => c.City)
                                .Include( r => r.User)
                                .Where(r => r.RestaurantId==restaurantId)
                                .ToListAsync();
           foreach(var review in reviews)
            {
                var reviewComment = await _context
                                          .ReviewComment
                                          .Where(rc => rc.ReviewId == review.Id)
                                          .ToListAsync();
                var reviewLikes = _context
                                  .ReviewLike
                                  .Where(rl => rl.ReviewId == review.Id)
                                  .Count();

                ReviewAC reviewAC = new ReviewAC();
                reviewAC.Review = review;
                reviewAC.ReviewComment = reviewComment;
                reviewAC.TotalLike = reviewLikes;

                AllReviews.Add(reviewAC);
            }

            return AllReviews;
        }

        public async Task<IEnumerable<ReviewAC>> GetAllReviewOfUser(int userId)
        {
            var reviews = await _context
                              .Review
                              .Include(r => r.Restaurant)
                              .ThenInclude(c => c.City)
                              .Include(r => r.User)
                              .Where(r => r.UserId == userId)
                              .ToListAsync();
            foreach (var review in reviews)
            {
                var reviewComment = await _context
                                          .ReviewComment
                                          .Where(rc => rc.ReviewId == review.Id)
                                          .ToListAsync();
                var reviewLikes = _context
                                  .ReviewLike
                                  .Where(rl => rl.ReviewId == review.Id)
                                  .Count();

                ReviewAC reviewAC = new ReviewAC();
                reviewAC.Review = review;
                reviewAC.ReviewComment = reviewComment;
                reviewAC.TotalLike = reviewLikes;

                ReviewsOfUser.Add(reviewAC);
            }

            return ReviewsOfUser;
        }

        public async Task<ReviewComment> GetComment(int commentId)
        {
            return await _context.ReviewComment.FindAsync(commentId);
        }

        public void UpdateReview(Review review)
        {
            throw new NotImplementedException();
        }

      
    }
}
