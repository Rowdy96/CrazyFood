using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Follow
    {
        #region Public Propertry
        public int Id { get; set; }
        [ForeignKey("Users")]
        public string FollowingUserId { get; set; }
        public Users FollowingUser { get; set; }
        [ForeignKey("Users")]
        public string FollowedUserId { get; set; }
        public Users FollowedUser { get; set; }
        public bool IsFollowed { get; set; }
        #endregion
    }
}
