using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.Follow
{
    public interface IFollowRepository
    {
        #region Methods
        Task<IEnumerable<Users>> GetAllFollowers(int followingId);
        Task<int> GetTotalNumberOfFollowers(int followingId);
        #endregion
    }
}
