using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPL.Models
{
    public class CommentVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int PostId { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Enter your comment")]
        public string Entity { get; set; }
    }
}