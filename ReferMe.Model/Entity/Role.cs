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
    
    public partial class Role
    {
        public Role()
        {
            this.UserRoleMapping = new HashSet<UserRoleMapping>();
        }
    
        public int id { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDisplayName { get; set; }
    
        public virtual ICollection<UserRoleMapping> UserRoleMapping { get; set; }
    }
}
