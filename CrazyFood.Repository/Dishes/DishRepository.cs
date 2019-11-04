using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace CrazyFood.Repository.Dishes
{
    public class DishRepository : IDishRepository
    {
        private readonly CrazyFoodContext _context;

        public DishRepository(CrazyFoodContext context)
        {
            this._context = context;
        }

        public async Task CreateDish(int menuId, Dish dish)
        {
            dish.MenuCategoryId = menuId;
            await _context.Dish.AddAsync(dish);
        }

        public async Task DeleteDish(int dishId)
        {
            var dish = await _context.Dish.FindAsync(dishId);
            dish.IsDeleted = true;
           // _context.Dish.Remove(dish);
        }

        public async Task<IEnumerable<Dish>> GetAllDishOfMenu(int menuId)
        {
            return await _context
                        .Dish
                        .Where(d => d.MenuCategoryId == menuId && d.IsDeleted == false )
                        .ToListAsync();
        }

        public async Task<Dish> GetDish(int dishId)
        {
            return await _context
                         .Dish
                         .Where(d => d.IsDeleted == false)
                         .FirstOrDefaultAsync(d => d.Id == dishId);
        }

        public void UpdateDish(Dish dish)
        {
            _context.Dish.Update(dish);
        }

       
    }
}
