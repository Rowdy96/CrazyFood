using CrazyFood.DomainModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Data
{
    public class CrazyFoodContext :IdentityDbContext
    {

        public CrazyFoodContext(DbContextOptions<CrazyFoodContext> options) 
            : base(options)
        {
            
        }

        public DbSet<City> City { get; set; }
        public DbSet<Cuisine> Cuisine { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<MenuCategory> MenuCategory { get; set; }
        public DbSet<Dish> Dish { get; set; }

        public DbSet<Review> Review { get; set; }
        public DbSet<ReviewComment> ReviewComment { get; set; }
        public DbSet<ReviewLike> ReviewLike { get; set; }
        public DbSet<AverageRating> AverageRating { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<Users> User { get; set; }
        public DbSet<Follow> Follow { get; set; }
        public DbSet<UserRole> UserRole { get; set; }


    }
}
