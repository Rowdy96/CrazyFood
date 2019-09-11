using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyFood.Repository.User
{
    public interface IUserRepository
    {
       UserAC GetUser(Users user);
    }
}
