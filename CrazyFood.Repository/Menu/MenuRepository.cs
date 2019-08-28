﻿using System;
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
        public List<MenuAC> MenuList = new List<MenuAC>();

        public MenuRepository(CrazyFoodContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<MenuAC>> MenusOfRestaurant(int id)
        {
            var menusOfRestaurant = await _context
                            .MenuCategory
                            .Where(m => m.RestaurantId == id)
                            .ToListAsync();
            foreach (var menu in menusOfRestaurant)
            {

                MenuAC menuAC = new MenuAC();
                menuAC.MenuCategoryName = menu.MenuCategoryName;
                var Dishes = await _context
                                          .Dish
                                          .Where(d => d.MenuCategoryId == menu.Id)
                                          .ToListAsync();

                List<DishAC> DishesOfMenu = new List<DishAC>();

                foreach (var dish in Dishes)
                {
                    DishAC dishAC = new DishAC();
                    dishAC.DishName = dish.DishName;
                    dishAC.DishPrice = dish.Price;
                    DishesOfMenu.Add(dishAC);
                }
                menuAC.Dishes = DishesOfMenu;
                MenuList.Add(menuAC);
            }

            return MenuList;
        }

        public async Task<MenuAC> GetMenu(int menuId)
        {
            var category = await _context.MenuCategory.FindAsync(menuId);
            var dishes = await _context.Dish.Where(d => d.MenuCategoryId == menuId).ToListAsync();

            MenuAC menuAC = new MenuAC();
            menuAC.MenuCategoryName = category.MenuCategoryName;
            List<DishAC> dishACs = new List<DishAC>();
            foreach (var d in dishes)
            {
                DishAC dish = new DishAC();
                dish.DishName = d.DishName;
                dish.DishPrice = d.Price;
                dishACs.Add(dish);
            }
            menuAC.Dishes = dishACs;
            return menuAC;
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
