using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.ReviewComments
{
    public interface IReviewCommentRepository
    {
        Task<IEnumerable<ReviewComment>> GetAllReviewComment(int reviewId);
        Task<ReviewComment> GetReviewComment(int? reviewCommentId);
        Task AddReviewComment(int userId,int reviewId, ReviewComment reviewComment);
        Task UpdaAddReviewCommentteDish(ReviewComment reviewComment);
        Task DeleteReviewComment(int id);
    }
}
