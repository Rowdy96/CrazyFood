using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Core.ApiControllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("{restaurantId}")]
        public async Task<IEnumerable<Review>> GetReviewsOfRestaurant([FromRoute] int restaurantId)
        {
            return await _unitOfWork.ReviewRepository.GetAllReviewsOfRestaurant(restaurantId);
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Review>> GetReviewsOfUser([FromRoute] int userId)
        {
            return await _unitOfWork.ReviewRepository.GetAllReviewsOfUser(userId);
        }

        [HttpGet("{reviewId}")]
        public async Task<Review> GetReview([FromRoute] int reviewId)
        {
            return await _unitOfWork.ReviewRepository.GetReviewById(reviewId);
        }

        [HttpPost("{restaurantId}")]
        public async Task<IActionResult> CreateReview([FromRoute] int restaurantId,
                                                      [FromBody] Review review )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            review.RestaurantId = restaurantId;
            await _unitOfWork.ReviewRepository.AddReview(review);
            await _unitOfWork.Save();
            return Ok(review);
        }
        
       [HttpDelete("{reviewId}")]
       public async Task<IActionResult> DeleteReview([FromRoute] int reviewId)
       {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = await _unitOfWork.ReviewRepository.GetReviewById(reviewId);
            if(review == null)
            {
                return NotFound();
            }

            await _unitOfWork.ReviewRepository.DeleteDish(reviewId);
            await _unitOfWork.Save();

            return Ok(review);
        }
    }
}
