using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;

namespace CrazyFood.Repository.Dishes
{
    public class DishRepository : IDishRepository
    {
        #region Public methods
        public Task CreateDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDish(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Dish>> GetAllDishes(int menuCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Dish> GetDishById(int? dishId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDish(Dish dish)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
