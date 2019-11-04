using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using Microsoft.EntityFrameworkCore;

namespace CrazyFood.Repository.Follows
{
    public class FollowRepository : IFollowRepository
    {
        private CrazyFoodContext _context;
        private readonly IMapper _mapper;
        public FollowRepository(CrazyFoodContext context,
                                IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FollowAC> FollowUser(FollowAC followAC)
        {
            if(await IsExists(followAC.FollowingUserId , followAC.FollowedUserId)!=null)
            {
                var followUser = await IsExists(followAC.FollowingUserId, followAC.FollowedUserId);
                followUser.IsFollowed = true;
                _context.Follow.Update(followUser);

            }

            else
            {
                await _context.Follow.AddAsync(new Follow
                {
                    FollowedUserId = followAC.FollowedUserId,
                    FollowingUserId = followAC.FollowingUserId,
                    IsFollowed = true
                });

                followAC.IsFollowed = true;
            }
           
            return followAC;
        }

        public async Task UnFollow(FollowAC followAC)
        {
            var userfollowed = await _context
                                .Follow
                                .Where(ob => ob.FollowingUserId == followAC.FollowedUserId && ob.FollowedUserId == followAC.FollowingUserId)
                                .FirstOrDefaultAsync();

            userfollowed.IsFollowed = false;

            _context.Follow.Update(userfollowed);
        }

        public async Task<IEnumerable<FollowAC>> ListOfFollowersOfUser(string userId)
        {
            List<Follow> Followers = await _context
                                            .Follow
                                            .Include(o=>o.FollowedUser)
                                            .Include(o =>o.FollowingUser)
                                            .Where(ob => ob.FollowedUserId == userId && ob.IsFollowed == true)
                                            .ToListAsync();

            List<FollowAC> FollowerAcs = new List<FollowAC>();
            foreach (var follower in Followers)
            {
                FollowAC followAC = new FollowAC();
                followAC.Id = follower.Id;
                followAC.FollowedUserId = follower.FollowedUserId;
                followAC.FollowingUserId = follower.FollowingUserId;

                followAC.FollowingUser = new UserAC
                {
                    Id = follower.FollowingUser.Id,
                    Name = follower.FollowingUser.Name,
                    Phone = follower.FollowingUser.PhoneNumber,
                    Email = follower.FollowingUser.Email,
                    Address = follower.FollowingUser.Address
                };

                followAC.FollowedUser = new UserAC
                {
                    Id = follower.FollowingUser.Id,
                    Name = follower.FollowingUser.Name,
                    Phone = follower.FollowingUser.PhoneNumber,
                    Email = follower.FollowingUser.Email,
                    Address = follower.FollowingUser.Address
                };

                followAC.IsFollowed = follower.IsFollowed;
                FollowerAcs.Add(followAC);  
            }

            return FollowerAcs;
                          
        }

        public async Task<Follow> IsExists(string followingId, string followedId)
        {
            var userfollowed = await _context
                                .Follow
                                .Where(ob => ob.FollowingUserId == followingId && ob.FollowedUserId == followedId)
                                .FirstOrDefaultAsync();

            if (userfollowed == null)
            {
                return null;
            }
            return userfollowed;
        }
    }
}
