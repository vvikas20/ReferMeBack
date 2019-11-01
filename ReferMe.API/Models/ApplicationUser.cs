using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReferMe.API.Models
{
    public class ApplicationUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
        public string UserRole { get; set; }
    }
}