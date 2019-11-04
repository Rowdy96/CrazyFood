using CrazyFood.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.Repository.Restaurants;
using CrazyFood.Repository.Menu;
using CrazyFood.Repository.Dishes;
using CrazyFood.Repository.Reviews;
using CrazyFood.Repository.Orders;
using CrazyFood.Repository.User;
using CrazyFood.Repository.Follows;

namespace CrazyFood.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Propertry
        IRestaurantRepositary restaurant { get; }
        IMenuRepository Menu { get; }
        IDishRepository Dish { get; }
        IReviewRepository Review { get; }
        IOrderRepository OrderRepository { get; }
        IUserRepository UserRepository { get;  }
        IFollowRepository FollowRepository { get; }
        #endregion

        #region Method
        Task Save();
        #endregion
    }
}
