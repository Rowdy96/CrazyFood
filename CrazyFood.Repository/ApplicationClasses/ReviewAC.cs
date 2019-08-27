using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class ReviewAC
    {
        public Review Review { get; set; }
        public ReviewLike ReviewLike { get; set; }
        public ReviewComment Comment { get; set; }

        public int TotalLike { get; set; }
        public ICollection<ReviewComment> ReviewComment { get; set; }
    }
}
