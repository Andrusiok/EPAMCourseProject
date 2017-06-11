using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPL.Models
{
    public class BlogPostVM
    {
        public BlogVM Blog { get; set; }
        public IEnumerable<FullPostVM> Posts { get; set; }
    }
}