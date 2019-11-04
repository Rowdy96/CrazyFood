using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Follows
{
    public interface IFollowRepository
    {
        Task<FollowAC> FollowUser(FollowAC followAC);
        Task UnFollow(FollowAC followAC);
        Task<IEnumerable<FollowAC>> ListOfFollowersOfUser(string userId);
        Task<Follow> IsExists(string followingId, string followedId);

    }
}
