using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Model.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
        public string ProfilePath { get; set; }
        public string ResumePath { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public int UserRoleID { get; set; }
    }
}
