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

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<User> User { get; set; }

    }
}
