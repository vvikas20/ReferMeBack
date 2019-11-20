//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReferMe.Model.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Post = new HashSet<Post>();
            this.Referral = new HashSet<Referral>();
            this.UserRoleMapping = new HashSet<UserRoleMapping>();
        }
    
        public int id { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string ProfileImagePath { get; set; }
        public string ResumePath { get; set; }
        public System.DateTime CreatedOnDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Verified { get; set; }
        public bool Active { get; set; }
    
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Referral> Referral { get; set; }
        public virtual ICollection<UserRoleMapping> UserRoleMapping { get; set; }
    }
}
