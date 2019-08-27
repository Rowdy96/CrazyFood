using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class ReviewComment
    {
        #region Public Propertry
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }

        #region Navigation Propertry
        //public Users User { get; set; }
        public int ReviewId { get; set; }
       // public Review Review { get; set; }

        #endregion
        #endregion
    }
}
