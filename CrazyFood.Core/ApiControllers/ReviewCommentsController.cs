using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Core.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewCommentsController : ControllerBase
    {
        #region Private Variables
        #region Dependencies 
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #endregion

        #region Controllers
        public ReviewCommentsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        [HttpGet("{reviewId}")]
        public async Task<IEnumerable<ReviewComment>> GetAllCommentsOfReview([FromRoute] int reviewId)
        {
            return await _unitOfWork.ReviewCommentRepository.GetAllReviewComment(reviewId);
        }
        

        [HttpGet("{reviewCommentId}")]
        public async Task<ReviewComment> GetAllComment([FromRoute] int reviewCommentId)
        {
            return await _unitOfWork.ReviewCommentRepository.GetReviewComment(reviewCommentId);
        }


        [HttpPost("{userId}/{reviewId}")]
        public async Task<IActionResult> AddReviewComment([FromRoute] int userId, 
                                                          [FromRoute] int reviewId,
                                                          [FromBody]ReviewComment reviewComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.ReviewCommentRepository.AddReviewComment(userId, reviewId, reviewComment);
            await _unitOfWork.Save();

            return Ok(reviewComment);
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReviewComment([FromRoute] int reviewId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewComment = await _unitOfWork.ReviewCommentRepository.GetReviewComment(reviewId);
            if (reviewComment == null)
            {
                return NotFound();
            }

            await _unitOfWork.ReviewCommentRepository.DeleteReviewComment(reviewId);
            await _unitOfWork.Save();

            return Ok(reviewComment);
        }
        #endregion

    }
}
