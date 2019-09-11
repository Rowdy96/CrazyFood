using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Data;
using CrazyFood.Repository.Dishes;
using CrazyFood.Repository.Menu;
using CrazyFood.Repository.Orders;
using CrazyFood.Repository.Restaurants;
using CrazyFood.Repository.Reviews;
using CrazyFood.Repository.User;

namespace CrazyFood.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Variables

        #region Dependencies
        private readonly CrazyFoodContext _context;
        private IRestaurantRepositary _restaurant;
        private IMenuRepository _menu;
        private IDishRepository _dish;
        private IReviewRepository _review;
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        #endregion

        #endregion

        #region Public propertry

        public IRestaurantRepositary restaurant
        {
            get
            {
                _restaurant = new RestaurantRepositary(_context);
                return _restaurant;
            }
        }

        public IMenuRepository Menu
        {
            get
            {
                _menu = new MenuRepository(_context);
                return _menu;
            }
        }

        public IDishRepository Dish
        {
            get
            {
                _dish = new DishRepository(_context);
                return _dish;
            }
        }

        public IReviewRepository Review
        {
            get
            {
                _review = new ReviewRepository(_context);
                return _review;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                _orderRepository = new OrderRepository(_context);
                return _orderRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }
        #endregion

        #region Construcor 
        public UnitOfWork(CrazyFoodContext context)
        {
            this._context = context;
        }
        #endregion
        #region Public Method

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
