using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM
{
    public class User
    {
        public User()
        {
            Likes = new List<Like>();
            Comments = new List<Comment>();
        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}