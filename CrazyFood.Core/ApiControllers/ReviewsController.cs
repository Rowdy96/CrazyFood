using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Core.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public ReviewsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //api/Reviews/GetReviewsOfRestaurant/1
        [HttpGet("{restaurantId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<ReviewAC>> GetReviewsOfRestaurant([FromRoute] int restaurantId)
        {
            return await _unitOfWork.Review.GetAllReviewOfRestaurant(restaurantId);
        }

        //api/Reviews/GetReviewsOfUser/1
        [HttpGet("{userId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<ReviewAC>> GetReviewsOfUser([FromRoute] string userId)
        {
            return await _unitOfWork.Review.GetAllReviewOfUser(userId);
        }

        //api/Reviews/GetReview/1
        [HttpGet("{reviewId}")]
        [AllowAnonymous]
        public async Task<ReviewAC> GetReview([FromRoute] int reviewId)
        {
            return await _unitOfWork.Review.GetReview(reviewId);
        }

        //api/Reviews/AddReviw/1
        [Authorize]
        [HttpPost("{restaurantId}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddReviw([FromBody] Review review )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ReviewAC reviewAc = new ReviewAC();
            reviewAc.Review = review;
            await _unitOfWork.Review.AddReview(reviewAc);
            await _unitOfWork.Save();
            return Ok(review);
        }

        //api/Reviews/AddComment/1
        [Authorize]
        [HttpPost("{reviewId}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddComment([FromRoute] int reviewId
                                                  , [FromBody] ReviewComment reviewComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReviewAC reviewAC = new ReviewAC();
            reviewAC.Comment = reviewComment;
            await _unitOfWork.Review.AddReviewComment(reviewId, reviewAC);
            await _unitOfWork.Save();
            return Ok(reviewComment);
        }

        //api/Reviews/GetComment/1
        [HttpGet("{commentId}")]
        [AllowAnonymous]
        public async Task<ReviewComment> GetComment([FromRoute]int commentId)
        {
            return await _unitOfWork.Review.GetComment(commentId);
        }

        //api/Reviews/AddLike/1
        [Authorize]
        [HttpPost("reviewId")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddLike([FromRoute] int reviewId
                                                ,[FromBody] ReviewLike reviewLike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReviewAC reviewAC = new ReviewAC();
            reviewAC.ReviewLike = reviewLike;

            await _unitOfWork.Review.AddLike(reviewId, reviewAC);
            await _unitOfWork.Save();
            return Ok(reviewLike);

        }

        //api/Reviews/AddRating/1
        [Authorize]
        [HttpPost("{reviewId}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddRating([FromRoute] int restaurantId,
                                                   [FromBody] Review reviewRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ReviewAC reviewAc = new ReviewAC();
            reviewAc.Review = reviewRating;
            await _unitOfWork.Review.AddRating(restaurantId, reviewAc);
            await _unitOfWork.Save();
            return Ok(reviewRating);
        }
    }
}
