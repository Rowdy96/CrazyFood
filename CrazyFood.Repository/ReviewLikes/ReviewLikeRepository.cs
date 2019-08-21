using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.ReviewLikes
{
    public class ReviewLikeRepository : IReviewLikeRepository
    { 
        Task IReviewLikeRepository.AddLikeToReview(int reviewId, int userId, ReviewLike reviewLike)
        {
            throw new NotImplementedException();
        }

        Task<int> IReviewLikeRepository.GetAllLikesOfReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        
    }
}
