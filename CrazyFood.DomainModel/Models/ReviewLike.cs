using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class ReviewLike
    {
        #region Public Propertry
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsLiked { get; set; }
        #region Navigation Propertry
        public int ReviewId { get; set; }
       // public Review Review{ get; set; }
        public Users User { get; set; } 
        #endregion
        #endregion
    }
}
