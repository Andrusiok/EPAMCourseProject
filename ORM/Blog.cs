﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    public class Blog
    {
        public Blog()
        {
            Posts = new List<Post>();
        }

        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}