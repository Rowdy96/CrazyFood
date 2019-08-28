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
        public ICollection<ReviewComment> ReviewComment { get; set; }

        //************************************************************
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public int TotalLike { get; set; }
        public UserAC userAC { get; set; }
        public ICollection<ReviewCommentAC> ReviewCommnets { get; set; }
        public int RestaurantId { get; set; }
        
        
    }
}
