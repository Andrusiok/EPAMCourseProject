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

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}