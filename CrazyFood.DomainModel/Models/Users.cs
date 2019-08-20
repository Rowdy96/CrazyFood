using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.DomainModel.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoleId { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public UserRole Role { get; set; }
    }
}
