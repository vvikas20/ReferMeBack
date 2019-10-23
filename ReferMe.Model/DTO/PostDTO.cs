using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Model.DTO
{
    public class PostDTO
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public int MinExp { get; set; }
        public int MaxExp { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
    }
}
