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
    public class ReviewLikesContoller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewLikesContoller(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("{reviewId}")]
        public async Task<int> GetAllLikes([FromRoute]int reviewId)
        {
            return await _unitOfWork.ReviewLikeRepository.GetAllLikesOfReview(reviewId);
        }

        [HttpPost("{userId}/{reviewId}")]
        public async Task<IActionResult> CreateReview([FromRoute] int userId,
                                                      [FromRoute] int reviewId,
                                                      [FromBody] ReviewLike reviewLike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.ReviewLikeRepository.AddLikeToReview(reviewId, userId, reviewLike);
            await _unitOfWork.Save();
            return Ok(reviewLike);
        }

    }
}
