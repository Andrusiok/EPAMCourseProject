using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPL.Models
{
    public class FullPostVM
    {
        public PostVM Post { get; set; }
        public int Comments { get; set; }
        public IEnumerable<LikeVM> Likes { get; set; }
    }
}