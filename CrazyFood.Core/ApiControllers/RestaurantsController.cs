using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
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
    public class RestaurantsController:ControllerBase
    {
        private  IUnitOfWork _unitOfWork;
        public RestaurantsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //api/Restaurants/GetAll
        [HttpGet]
        public async Task<IEnumerable<ListOfRestaurant>> GetAll()
        {
            return await _unitOfWork
                        .ListOfRestaurantRepositary
                        .Restaurants();
        }

        //api/Restaurants/RestaurantsOfCity/1
        [HttpGet("{cityId}")]
        public async Task<IEnumerable<ListOfRestaurant>> RestaurantsOfCity([FromRoute] int cityId)
        {
            return await _unitOfWork
                        .ListOfRestaurantRepositary
                        .GetRestaurantsOfACity(cityId);
        }
    }
}
