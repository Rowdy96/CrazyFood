using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Restaurants
{
    public interface IRestaurantRepository
    {
        #region methods
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
        Task<Restaurant> GetRestaurantById(int? id);
        Task CreateRestaurant(Restaurant restaurant);
        Task UpdateRestaurant(Restaurant restaurant);
        Task DeleteRestaurant(int id);
        #endregion
    }
}
