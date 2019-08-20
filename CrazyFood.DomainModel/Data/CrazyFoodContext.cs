using CrazyFood.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Data
{
    public class CrazyFoodContext :DbContext
    {
        public CrazyFoodContext()
        {
                
        }

        public CrazyFoodContext(DbContextOptions<CrazyFoodContext> options) 
            : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewComment> ReviewComments { get; set; }
        public DbSet<ReviewLike> ReviewLikes { get; set; }
        public DbSet<AverageRating> AverageRatings { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


    }
}
