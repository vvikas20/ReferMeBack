using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Model.DTO
{
    public class JobDTO
    {
        public PostDTO PostDetail { get; set; }
        public UserDTO UserDetail { get; set; }
        public bool Applied { get; set; }
        public ReferralDTO ReferralDetail { get; set; }
    }
}
