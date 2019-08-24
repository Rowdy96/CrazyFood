using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class ListOfRestaurant
    {
        public Restaurant Restaurant { get; set; }
        public AverageRating AverageRating { get; set; }
    }
}
