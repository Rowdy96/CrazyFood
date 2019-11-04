using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //AverageRatingOfResaturant(restaurantId);
        }

        public async Task AddReview(ReviewAC review)
        {
           /// review.Review.RestaurantId = restaurantId;
            await _context.Review.AddAsync(review.Review);
            await AverageRatingOfResaturant(review.Review.RestaurantId);
        }

        public async Task AddReviewComment(int reviewId, ReviewAC reviewComment)
        {
            reviewComment.Comment.ReviewId = reviewId;
            await _context.ReviewComment.AddAsync(reviewComment.Comment);
        }

        public void UpdateReview(Review review)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<ReviewAC>> GetAllReviewOfRestaurant(int restaurantId)
        {
            var reviews = await _context
                                .Review
                                .Include(r => r.Restaurant)
                                .ThenInclude(c => c.City)
                                .Include( r => r.User)
                                .Where(r => r.RestaurantId == restaurantId && r.ReviewText != null)
                                .ToListAsync();

           foreach(var review in reviews)
            {
                var reviewComments = await _context
                                          .ReviewComment
                                          .Where(rc => rc.ReviewId == review.Id)
                                          .ToListAsync();
                var totalReviewComments =  _context
                                          .ReviewComment
                                          .Where(r => r.ReviewId == review.Id)
                                          .Count();
                var reviewLikes = _context
                                  .ReviewLike
                                  .Where(rl => rl.ReviewId == review.Id)
                                  .Count();

                List<ReviewCommentAC> ListOfComment = new List<ReviewCommentAC>();

                foreach (var reviewCommnet in reviewComments)
                {
                    ReviewCommentAC reviewCommentAC = new ReviewCommentAC();
                    reviewCommentAC.ReviewCommentId = reviewCommnet.Id;
                    reviewCommentAC.ReviewCommentText = reviewCommnet.CommentText;
                    reviewCommentAC.UserId = reviewCommnet.UserId;
                    reviewCommentAC.UserName = reviewCommnet.User.UserName;

                    ListOfComment.Add(reviewCommentAC);
                }

                ReviewAC reviewAC = new ReviewAC();
                UserAC user = new UserAC();
                user.Id = review.User.Id;
                user.Name = review.User.UserName;
                user.Phone = review.User.PhoneNumber;
                user.Email = review.User.Email;
                user.Address = review.User.Address;

                reviewAC.ReviewId = review.Id;
                reviewAC.Rating = review.Rating;
                reviewAC.ReviewText = review.ReviewText;
                reviewAC.userAC = user;
                reviewAC.ReviewCommnets = ListOfComment;
                reviewAC.TotalLike = reviewLikes;
                reviewAC.TotalComment = totalReviewComments;
                reviewAC.RestaurantId = restaurantId;

                AllReviews.Add(reviewAC);
            }

            return AllReviews;
        }

        public async Task<IEnumerable<ReviewAC>> GetAllReviewOfUser(string userId)
        {
            var reviews = await _context
                              .Review
                              .Include(r => r.Restaurant)
                              .ThenInclude(c => c.City)
                              .Include(r => r.User)
                              .Where(r => r.UserId == userId && r.ReviewText!=null)
                              .ToListAsync();

            foreach (var review in reviews)
            {
                var reviewComments = await _context
                                          .ReviewComment
                                          .Include(r=> r.User)
                                          .Where(rc => rc.ReviewId == review.Id)
                                          .ToListAsync();
                var totalReviewComments = _context
                                          .ReviewComment
                                          .Where(r => r.ReviewId == review.Id)
                                          .Count();
                var reviewLikes = _context
                                  .ReviewLike
                                  .Where(rl => rl.ReviewId == review.Id)
                                  .Count();

                List<ReviewCommentAC> ListOfComment = new List<ReviewCommentAC>();

                foreach (var reviewCommnet in reviewComments)
                {
                    ReviewCommentAC reviewCommentAC = new ReviewCommentAC();
                    reviewCommentAC.ReviewCommentId = reviewCommnet.Id;
                    reviewCommentAC.ReviewCommentText = reviewCommnet.CommentText;
                    reviewCommentAC.UserId = reviewCommnet.UserId;
                    reviewCommentAC.UserName = reviewCommnet.User.UserName;

                    ListOfComment.Add(reviewCommentAC);
                }

                ReviewAC reviewAC = new ReviewAC();
                UserAC user = new UserAC();
                user.Id = review.User.Id;
                user.Name = review.User.UserName;
                user.Phone = review.User.PhoneNumber;
                user.Email = review.User.Email;
                user.Address = review.User.Address;

                reviewAC.ReviewId = review.Id;
                reviewAC.Rating = review.Rating;
                reviewAC.ReviewText = review.ReviewText;
                reviewAC.userAC = user;
                reviewAC.ReviewCommnets = ListOfComment;
                reviewAC.TotalLike = reviewLikes;
                reviewAC.TotalComment = totalReviewComments;
                reviewAC.RestaurantId = review.RestaurantId;
                reviewAC.RestaurantName = review.Restaurant.Name;
                ReviewsOfUser.Add(reviewAC);
            }

            return ReviewsOfUser;
        }

        public async Task<ReviewComment> GetComment(int commentId)
        {
            return await _context.ReviewComment.FindAsync(commentId);
        }

        public async Task<ReviewAC> GetReview(int reviewId)
        {
            var review = await _context
                              .Review
                              .Include(r => r.Restaurant)
                              .ThenInclude(c => c.City)
                              .Include(r => r.User)
                              .Where(r => r.Id == reviewId)
                              .SingleOrDefaultAsync();

            var reviewComments = await _context
                                          .ReviewComment
                                          .Include(r => r.User)
                                          .Where(rc => rc.ReviewId == review.Id)
                                          .ToListAsync();
            var reviewLikes = _context
                                  .ReviewLike
                                  .Where(rl => rl.ReviewId == review.Id)
                                  .Count();

            List<ReviewCommentAC> ListOfComments = new List<ReviewCommentAC>();
            
            foreach (var reviewCommnet in reviewComments)
            {
                ReviewCommentAC reviewCommentAC = new ReviewCommentAC();
                reviewCommentAC.ReviewCommentId = reviewCommnet.Id;
                reviewCommentAC.ReviewCommentText = reviewCommnet.CommentText;
                reviewCommentAC.UserId = reviewCommnet.UserId;
                reviewCommentAC.UserName = reviewCommnet.User.UserName;

                ListOfComments.Add(reviewCommentAC);
            }

            ReviewAC reviewAC = new ReviewAC();
            UserAC user = new UserAC();
            user.Id = review.User.Id;
            user.Name = review.User.UserName;
            user.Phone = review.User.PhoneNumber;
            user.Email = review.User.Email;
            user.Address = review.User.Address;

            reviewAC.ReviewId = review.Id;
            reviewAC.Rating = review.Rating;
            reviewAC.ReviewText = review.ReviewText;
            reviewAC.userAC = user;
            reviewAC.ReviewCommnets = ListOfComments;
            reviewAC.TotalLike = reviewLikes;
            reviewAC.RestaurantId = review.RestaurantId;

            return reviewAC;
        }

        public async Task AverageRatingOfResaturant(int restaurantId)
        {
            AverageRating averageRating = new AverageRating();

            var AverageUserRating = (int)await _context
                              .Review
                              .Where(r => r.RestaurantId == restaurantId)
                              .Select(r => r.Rating)
                              .AverageAsync();

            averageRating.AverageUserRating = AverageUserRating;

            if (averageRating.AverageUserRating<=5 && averageRating.AverageUserRating > 4)
            {
                averageRating.RatingText = "Excellent";

            }
            else if(averageRating.AverageUserRating <= 4 && averageRating.AverageUserRating > 3)
            {
                averageRating.RatingText = "Very Good";
            }
            else if (averageRating.AverageUserRating <= 3 && averageRating.AverageUserRating > 2)
            {
                averageRating.RatingText = "Good";
            }
            else
            {
                averageRating.RatingText = "Bad";
            }

            averageRating.Votes = _context.Review.Where(r => r.RestaurantId == restaurantId).Count();

            averageRating.RestaurantId = restaurantId;
            var IsAverageRatingExists =await _context.AverageRating.Where(a => a.RestaurantId == restaurantId).FirstOrDefaultAsync();

            if (IsAverageRatingExists == null)
            {
                _context.AverageRating.Add(averageRating);

            }else if (IsAverageRatingExists!=null)
            {
                _context.AverageRating.Update(averageRating);
            }
            
        }
    }
}
