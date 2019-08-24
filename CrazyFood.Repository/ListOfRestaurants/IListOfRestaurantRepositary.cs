using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.ListOfRestaurants
{
    public interface IListOfRestaurantRepositary
    {
        Task<IEnumerable<ListOfRestaurant>> Restaurants();
       
        Task<IEnumerable<ListOfRestaurant>> GetRestaurantsOfACity(int cityId);
    }
}
