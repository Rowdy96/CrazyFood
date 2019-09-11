using System.Collections.Generic;

namespace CrazyFood.Repository.ApplicationClasses
{
    public class UserAC
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}