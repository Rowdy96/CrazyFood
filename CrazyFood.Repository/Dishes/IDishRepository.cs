using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Dishes
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetAllDishOfMenu(int menuId);
        Task<Dish> GetDish(int dishId);
        Task CreateDish(int menuId,Dish dish);
        void UpdateDish(Dish dish);
        Task DeleteDish(int dishId);
            
    }
}
