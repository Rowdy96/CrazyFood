using CrazyFood.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.User
{
    public interface IUserRepository
    {
        #region Methods
        IEnumerable<Users> GetAllUser();
        Task<Users> GetUserById(int? userId);
        Task CreateUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(int id);
        #endregion

    }
}
