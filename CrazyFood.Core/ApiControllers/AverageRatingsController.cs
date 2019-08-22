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
    public class AverageRatingsController : ControllerBase
    {
        #region Private Controllers

        #region Dependencies
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #endregion

        #region Public Methods
        public AverageRatingsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("restaurantId")]
        public async Task<AverageRating> GetAverageRatingOfRestaurant(int restaurantId)
        {
            return await _unitOfWork.AverageRatingRepository.GetAverageRatingOfRestaurant(restaurantId);
        }

        #endregion
    }
}
