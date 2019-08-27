using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Restaurants
{
    public interface IRestaurantRepositary
    {
        Task<IEnumerable<ListOfRestaurant>> Restaurants();
        Task<IEnumerable<ListOfRestaurant>> GetRestaurantsOfACity(int cityId);
        Task<ListOfRestaurant> GetRestaurantById(int restaurantId);
        Task CreateRestaurant(Restaurant restaurant);
        void UpadateRestaurant(Restaurant restaurant);
        Task DeleteRestaurant(int restaurantId);
    }
}
