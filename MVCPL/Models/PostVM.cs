using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCPL.Models
{
    public class PostVM
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        [Required(ErrorMessage ="You have to enter a title")]
        public string Title { get; set; }
        [Display(Name ="Short Description")]
        [Required(ErrorMessage = "You have to enter a short description for your post")]
        public string Annotation { get; set; }
        [Required(ErrorMessage ="Enter text")]
        public string Text { get; set; }
    }
}