using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Model.DTO
{
    public class UserPostDTO
    {
        public PostDTO PostDetail { get; set; }
        public UserDTO UserDetail { get; set; }
    }
}
