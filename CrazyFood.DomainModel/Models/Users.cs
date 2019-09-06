using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Users : IdentityUser
    {
        #region Public Propertry
        public string Name { get; set; }
        public string Address { get; set; }

        //#region Navigation Propertry
        //public int RoleId { get; set; }
        //public UserRole Role { get; set; }
        #endregion
        
    }
}
