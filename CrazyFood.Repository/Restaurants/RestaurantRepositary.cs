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

        public List<ListOfRestaurant> AllRestaurants = new List<ListOfRestaurant>();
        public List<ListOfRestaurant> RestaurantsOfCity = new List<ListOfRestaurant>();

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
            _context.Restaurant.Remove(restaurant);
        }

        public void UpadateRestaurant(Restaurant restaurant)
        {
            _context.Restaurant.Update(restaurant);
        }

        public async Task<IEnumerable<ListOfRestaurant>> Restaurants()
        {

            var restaurants = await _context.Restaurant.Include(r => r.City).ToListAsync();
            foreach (var restaurant in restaurants)
            {
                ListOfRestaurant restaurantinfo = new ListOfRestaurant();
                restaurantinfo.Restaurant = restaurant;
                restaurantinfo.Restaurant.AverageRating = _context
                                                    .AverageRating
                                                    .Where(r => r.RestaurantId == restaurant.Id)
                                                    .FirstOrDefault();
                AllRestaurants.Add(restaurantinfo);
            }

            return AllRestaurants;
        }

        public async Task<IEnumerable<ListOfRestaurant>> GetRestaurantsOfACity(int cityId)
        {
            var restaurants = await _context
                                    .Restaurant
                                    .Include(r => r.City)
                                    .Where(r => r.CityId == cityId)
                                    .ToListAsync();

            foreach (var restaurant in restaurants)
            {
                ListOfRestaurant restaurantinfo = new ListOfRestaurant();
                restaurantinfo.Restaurant = restaurant;
                restaurantinfo.Restaurant.AverageRating = _context
                                                    .AverageRating
                                                    .Where(r => r.RestaurantId == restaurant.Id)
                                                    .FirstOrDefault();
                RestaurantsOfCity.Add(restaurantinfo);
            }

            return RestaurantsOfCity;
        }

        public async Task<ListOfRestaurant> GetRestaurantById(int restaurantId)
        {
            ListOfRestaurant restaurant = new ListOfRestaurant();
            restaurant.Restaurant = await _context.Restaurant.Include(r => r.City).FirstOrDefaultAsync(r => r.Id == restaurantId);
            restaurant.Restaurant.AverageRating = _context
                                                   .AverageRating
                                                   .Where(r => r.RestaurantId == restaurantId)
                                                   .FirstOrDefault();
            return restaurant;
        }
    }
}
