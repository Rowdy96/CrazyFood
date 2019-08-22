
using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.MenuCategories
{
    public interface IMenuCategoryRepository
    {
        #region methods
        Task<IEnumerable<MenuCategory>> GetMenuCategories(int restaurantId);
        Task<MenuCategory> GetMenuCategory(int? id);
        Task CreateMenuCategory(MenuCategory menuCategory);
        Task UpdateMenuCategory(MenuCategory menuCategory);
        Task DeleteMenuCategory(int id);
        #endregion
    }
}
