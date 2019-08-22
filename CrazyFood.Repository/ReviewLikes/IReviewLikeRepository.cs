using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.ReviewLikes
{
    public interface IReviewLikeRepository
    {
        #region methods
        Task<int> GetAllLikesOfReview(int reviewId);
        Task AddLikeToReview(int reviewId, int userId,ReviewLike reviewLike);
        #endregion
    }
}
