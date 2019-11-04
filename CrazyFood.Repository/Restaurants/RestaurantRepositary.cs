using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Restaurants
{
    public class RestaurantRepositary : IRestaurantRepositary
    {
        private readonly CrazyFoodContext _context;

        public List<RestaurantAC> AllRestaurants = new List<RestaurantAC>();
        public List<RestaurantAC> RestaurantsOfCity = new List<RestaurantAC>();

        public RestaurantRepositary(CrazyFoodContext context)
        {
            this._context = context;
        }

        public async Task CreateRestaurant(Restaurant restaurant)
        {
            await _context.Restaurant.AddAsync(restaurant);
        }

        public async Task DeleteRestaurant(int restaurantId)
        {
            var restaurant = await _context.Restaurant.FindAsync(restaurantId);
            restaurant.IsDeleted = true;
            //_context.Restaurant.Remove(restaurant);
        }

        public void UpadateRestaurant(Restaurant restaurant)
        {
            _context.Restaurant.Update(restaurant);
        }

        public async Task<IEnumerable<RestaurantAC>> Restaurants()
        {

            var restaurants = await _context.Restaurant
                                            .Where(r=>r.IsDeleted==false)
                                            .Include(r => r.City)
                                            .ToListAsync();

            foreach (var restaurant in restaurants)
            {
                RestaurantAC restaurantinfo = new RestaurantAC();
                restaurantinfo.Restaurant = restaurant;
                restaurantinfo.Restaurant.AverageRating = _context
                                                    .AverageRating
                                                    .Where(r => r.RestaurantId == restaurant.Id)
                                                    .FirstOrDefault();
                
                AllRestaurants.Add(restaurantinfo);
                
            }

            return AllRestaurants;
        }

        public async Task<IEnumerable<RestaurantAC>> GetRestaurantsOfACity(int cityId)
        {
            var restaurants = await _context
                                    .Restaurant
                                    .Where(r => r.IsDeleted == false)
                                    .Include(r => r.City)
                                    .Where(r => r.CityId == cityId)
                                    .ToListAsync();

            foreach (var restaurant in restaurants)
            {
                RestaurantAC restaurantinfo = new RestaurantAC();
                restaurantinfo.Restaurant = restaurant;
                restaurantinfo.Restaurant.AverageRating = _context
                                                    .AverageRating
                                                    .Where(r => r.RestaurantId == restaurant.Id)
                                                    .FirstOrDefault();
                RestaurantsOfCity.Add(restaurantinfo);
            }

            return RestaurantsOfCity;
        }

        public async Task<RestaurantAC> GetRestaurantById(int restaurantId)
        {
            RestaurantAC restaurant = new RestaurantAC();
            restaurant.Restaurant = await _context.Restaurant
                                                  .Where(r => r.IsDeleted == false)
                                                  .Include(r => r.City)
                                                  .Include(r=>r.AverageRating)
                                                  .FirstOrDefaultAsync(r => r.Id == restaurantId);

            //restaurant.Restaurant.AverageRating.AverageUserRating = AverageRatingOfResaturant(restaurantId);

            return restaurant;
        }

        //public int AverageRatingOfResaturant(int restaurantId)
        //{
        //    var averageRating = (int)_context
        //                      .Review
        //                      .Where(r => r.RestaurantId == restaurantId)
        //                      .Select(r => r.Rating)
        //                      .Average();

        //    return averageRating;

        //}

    }
}
