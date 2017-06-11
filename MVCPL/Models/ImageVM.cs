using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPL.Models
{
    public class ImageVM
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Path { get; set; }
    }
}