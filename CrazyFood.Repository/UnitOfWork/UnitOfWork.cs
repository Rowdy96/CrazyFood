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
    public class UnitOfWork : IUnitOfWork
    {
        #region Public propertry
        public IRestaurantRepository RestaurantRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IMenuCategoryRepository MenuCategoryRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDishRepository DishRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IOrderRepository OrderRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IOrderItemRepository OrderItemRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IReviewRepository ReviewRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IReviewLikeRepository ReviewLikeRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IReviewCommentRepository ReviewCommentRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IUserRepository UserRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFollowRepository FollowRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IAverageRatingRepository AverageRatingRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Public Method
        public Task Save()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
