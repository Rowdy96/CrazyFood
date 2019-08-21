using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Dishes
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetAllDishes(int menuCategoryId);
        Task<Dish> GetDishById(int? dishId);
        Task CreateDish(Dish dish);
        Task UpdateDish(Dish dish);
        Task DeleteDish(int id);
    }
}
