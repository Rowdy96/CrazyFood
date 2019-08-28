using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Menu
{
    public interface IMenuRepository
    {
        Task<IEnumerable<MenuAC>> MenusOfRestaurant(int id);
        Task<MenuAC> GetMenu(int menuId);
        Task CreateMenu(int restaurantId,MenuCategory menu);
        void UpdateMenu(MenuCategory menu);
        Task DeleteMenu(int id);
    }
}
