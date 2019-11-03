using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Model.DTO
{
    public class ReferralDTO
    {
        public int id { get; set; }
        public int ReferralID { get; set; }
        public int PostID { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public UserDTO CreatedByUserDetail { get; set; }
    }
}
