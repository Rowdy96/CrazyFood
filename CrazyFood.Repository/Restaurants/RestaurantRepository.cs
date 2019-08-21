using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;

namespace CrazyFood.Repository.Restaurants
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public Task CreateRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            throw new NotImplementedException();
        }

        public Task<Restaurant> GetRestaurantById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
