using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public int FollowingUserId { get; set; }
        public int FollowedUserId { get; set; }
    }
}
