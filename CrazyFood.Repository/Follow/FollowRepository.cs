using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;

namespace CrazyFood.Repository.Follow
{
    public class FollowRepository : IFollowRepository
    {

        #region Public methods
        public Task<IEnumerable<Users>> GetAllFollowers(int followingId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalNumberOfFollowers(int followingId)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
