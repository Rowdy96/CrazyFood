using CrazyFood.DomainModel.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private CrazyFoodContext _context;
        public UserRepository(CrazyFoodContext context)
        {
            this._context = context;
        }
    }
}
