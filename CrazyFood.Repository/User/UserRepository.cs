using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private CrazyFoodContext _context;

        public UserRepository(CrazyFoodContext context)
        {
            this._context = context;
        }

        public UserAC GetUser(Users user)
        {
            UserAC userAC = new UserAC();
            userAC.Id = user.Id;
            userAC.Name = user.Name;
            userAC.Email = user.Email;
            userAC.Phone = user.PhoneNumber;
            userAC.Address = user.Address;

            return userAC;
        }
    }
}
