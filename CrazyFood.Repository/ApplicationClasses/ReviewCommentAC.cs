using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class ReviewCommentAC
    {
        public int ReviewCommentId { get; set; }
        public string ReviewCommentText { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
