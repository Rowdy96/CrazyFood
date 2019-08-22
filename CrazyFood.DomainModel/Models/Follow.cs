using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Follow
    {
        #region Public Propertry
        public int Id { get; set; }
        public int FollowingUserId { get; set; }
        public int FollowedUserId { get; set; }
        #endregion
    }
}
