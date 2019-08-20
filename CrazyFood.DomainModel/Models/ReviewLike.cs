using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class ReviewLike
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int UserId { get; set; }

        public Review Review{ get; set; }
       // public Users User { get; set; } 
    }
}
