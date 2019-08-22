using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Models;

namespace CrazyFood.Repository.User
{
    public class UserRepository : IUserRepository
    {
        #region Public Propertry
        public Task CreateUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetUserById(int? userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(Users user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
