using CrazyFood.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.Repository.AverageRatings;
using CrazyFood.Repository.Dishes;
using CrazyFood.Repository.Follow;
using CrazyFood.Repository.MenuCategories;
using CrazyFood.Repository.OrderItems;
using CrazyFood.Repository.Orders;
using CrazyFood.Repository.Restaurants;
using CrazyFood.Repository.ReviewComments;
using CrazyFood.Repository.ReviewLikes;
using CrazyFood.Repository.Reviews;
using CrazyFood.Repository.User;

namespace CrazyFood.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Propertry
        IRestaurantRepository RestaurantRepository { get; set; }
        IMenuCategoryRepository MenuCategoryRepository { get; set; }
        IDishRepository DishRepository { get; set; }

        IOrderRepository OrderRepository { get; set; }
        IOrderItemRepository OrderItemRepository { get; set; }
       
        IReviewRepository ReviewRepository { get; set; }
        IReviewLikeRepository ReviewLikeRepository { get; set; }
        IReviewCommentRepository ReviewCommentRepository { get; set; }

        IUserRepository UserRepository { get; set; }
        IFollowRepository FollowRepository { get; set; }

        IAverageRatingRepository AverageRatingRepository { get; set; }
        #endregion

        #region Method
        Task Save();
        #endregion
    }
}
