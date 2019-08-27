using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CrazyFood.Repository.Menu
{
    public class MenuRepository : IMenuRepository
    {
        private readonly CrazyFoodContext _context;
        public List<MenuDishAC> MenuOfRestaurant = new List<MenuDishAC>();

        public MenuRepository(CrazyFoodContext context)
        {
            this._context = context;
        }

        public async  Task CreateMenu(int restaurantId ,MenuCategory menu)
        {
            menu.RestaurantId = restaurantId;
            await _context.MenuCategory.AddAsync(menu);
        }

        public async Task DeleteMenu(int id)
        {
            var menu =await _context.MenuCategory.FindAsync(id);
            _context.MenuCategory.Remove(menu);

        }

        public async Task<MenuDishAC> GetMenu(int menuId)
        {
            MenuDishAC menuDishAC = new MenuDishAC();
            menuDishAC.MenuCategory = await _context.MenuCategory.FindAsync(menuId);
            menuDishAC.MenuCategory.TotalDishes = CountTotalDishes(menuId);
            menuDishAC.Dishes = await _context
                                      .Dish
                                      .Where(d => d.MenuCategoryId == menuId)
                                      .ToListAsync();

            return menuDishAC;
        }

        public async Task<IEnumerable<MenuDishAC>> GetMenuOfRestaurant(int restaurantId)
        {
            var menusOfRestaurant = await _context
                            .MenuCategory
                            .Where(m => m.RestaurantId == restaurantId)
                            .ToListAsync();
            foreach (var menu in menusOfRestaurant)
            {
                MenuDishAC menuDishAC = new MenuDishAC();
                menuDishAC.MenuCategory = menu;
                menuDishAC.MenuCategory.TotalDishes = CountTotalDishes(menu.Id);
                menuDishAC.Dishes = await _context
                                          .Dish
                                          .Where(d => d.MenuCategoryId == menu.Id)
                                          .ToListAsync();
                MenuOfRestaurant.Add(menuDishAC);
            }

            return MenuOfRestaurant;
        }

        public void UpdateMenu(MenuCategory menu)
        {
             menu.TotalDishes = CountTotalDishes(menu.Id);
            _context.MenuCategory.Update(menu);
        }

        public int CountTotalDishes(int menuId)
        {
            return _context
                   .Dish
                   .Where(d => d.MenuCategoryId == menuId)
                   .Count();
        }
    }
}
