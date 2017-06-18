using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPL.Models
{
    public enum Role
    {
        Administrator = 1,
        User
    }

    public class UserVM
    {
        public int Id { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "You have to enter valid user login")]
        [RegularExpression("^(?=.{4,20}$)(?![_.])[a-zA-Z0-9._]+(?<![_.])$", ErrorMessage = "Incorrect User Login")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You have to enter valid user password")]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    public class RegisterVM : UserVM
    {
        [Display(Name = "Password")]
        [Required(ErrorMessage = "You have to enter valid user password")]
        [StringLength(15, MinimumLength = 6)]
        [Compare("PasswordConfirm", ErrorMessage = "Passwords don't match")]
        public string RegisterPassword { get; set; }
        [Display(Name = "Repeat password")]
        public string PasswordConfirm { get; set; }
    }
}