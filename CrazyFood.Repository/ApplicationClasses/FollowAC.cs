using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class FollowAC
    {
        public int Id { get; set; }
        public string FollowingUserId { get; set; }
        public UserAC FollowingUser { get; set; }
        public string FollowedUserId { get; set; }
        public UserAC FollowedUser { get; set; } 
        public bool IsFollowed { get; set; }
    }
}
