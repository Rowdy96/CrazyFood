using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;

namespace CrazyFood.Repository.MenuCategories
{
    public class MenuCategoryRepository : IMenuCategoryRepository
    {
        #region Public Methods
        public Task CreateMenuCategory(MenuCategory menuCategory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMenuCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MenuCategory>> GetMenuCategories(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task<MenuCategory> GetMenuCategory(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMenuCategory(MenuCategory menuCategory)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
