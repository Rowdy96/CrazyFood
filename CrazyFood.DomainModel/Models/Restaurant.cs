using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public decimal AverageCost { get; set; }
        public string OpeningHours { get; set; }
        public string RestaurantLocation { get; set; }
        public bool HasOnlineBooking { get; set; }

        public int CityId { get; set; }
      
        // public int CuisineId { get; set; }

        public City City { get; set; }

    }
}
