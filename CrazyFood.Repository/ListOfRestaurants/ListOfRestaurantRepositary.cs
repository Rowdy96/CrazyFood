using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using Microsoft.EntityFrameworkCore;

namespace CrazyFood.Repository.ListOfRestaurants
{
    public class ListOfRestaurantRepositary : IListOfRestaurantRepositary
    {
        private readonly CrazyFoodContext _context;
        public List<ListOfRestaurant> AllRestaurants = new List<ListOfRestaurant>();
        public List<ListOfRestaurant> RestaurantsOfCity = new List<ListOfRestaurant>();

        public ListOfRestaurantRepositary(CrazyFoodContext context)
        {
            this._context = context;
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
                                    .Where(r=> r.CityId ==cityId)
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

        
    }
}
