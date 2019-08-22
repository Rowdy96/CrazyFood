using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;

namespace CrazyFood.Repository.ReviewComments
{
    class ReviewCommentRepository : IReviewCommentRepository
    {
        #region Public methods
        public Task AddReviewComment(int userId,int reviewId, ReviewComment reviewComment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReviewComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewComment>> GetAllReviewComment(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewComment> GetReviewComment(int? reviewCommentId)
        {
            throw new NotImplementedException();
        }

        public Task UpdaAddReviewCommentteDish(ReviewComment reviewComment)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
