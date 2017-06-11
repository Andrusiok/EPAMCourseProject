using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPL.Models
{
    public class CommentVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime Date { get; set; }
        public string Entity { get; set; }
    }
}