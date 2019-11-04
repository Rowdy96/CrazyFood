using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Core.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public FollowController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        //api/Follow/FollowUser
        [HttpPost]
        public async Task<IActionResult> FollowUser([FromBody]FollowAC followAC)
        {

            var follow = await _unitOfWork.FollowRepository.FollowUser(followAC);
            await _unitOfWork.Save();
            return Ok(follow);
        }

        //api/Follow/UnFollowUser
        [HttpPut]
        public async Task<IActionResult> UnFollowUser([FromBody]FollowAC unfollowAC)
        {
            await _unitOfWork.FollowRepository.UnFollow(unfollowAC);
            await _unitOfWork.Save();
            return Ok(unfollowAC);
        }

        //api/Follow/ListOfFollowersOfUser/9525b151-a63a-4ba3-a177-18f7bd551c5f
        [HttpGet("{userId}")]
        public async Task<IEnumerable<FollowAC>> ListOfFollowersOfUser([FromRoute] string userId)
        {

            return await _unitOfWork
                            .FollowRepository
                            .ListOfFollowersOfUser(userId);
        }

        //api/Follow/IsFollowing/followedId/followingId
        [HttpGet("{followedId}/{followingId}")]
        public async Task<bool> IsFollowing([FromRoute] string followingId, string followedId)
        {
            var Follow = await _unitOfWork.FollowRepository.IsExists(followingId, followedId);
            if (Follow == null)
            {
                return false;
            }
            else if (!Follow.IsFollowed)
            {
                return false;
            }
            
            return true;
        }

        
    }
}
