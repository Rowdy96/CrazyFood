using AutoMapper;
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
        private IMapper _mapper;
        public UserRepository(CrazyFoodContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task FollowUser(Follow follow)
        {
            await _context.Follow.AddAsync(follow);
        }

        public UserAC GetUser(Users user)
        {
            UserAC userAC = new UserAC();
            userAC.Id = user.Id;
            userAC.Name = user.Name;
            userAC.Email = user.Email;
            userAC.Phone = user.PhoneNumber;
            userAC.Address = user.Address;
           // var users = _mapper.Map<UserAC>(user);
            return userAC;
        }

        public async Task UnFollowUser(Follow follow)
        {
            throw new NotImplementedException();
        }
    }
}
