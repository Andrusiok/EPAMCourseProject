using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPL.Models
{
    public class UserBlogVM
    {
        public UserVM User { get; set; }
        public BlogPostVM Blog { get; set; }
    }
}