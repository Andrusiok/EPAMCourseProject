using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPL.Models
{
    public class PostVM
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Annotation { get; set; }
    }
}