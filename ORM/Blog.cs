﻿using System;
using System.Collections.Generic;

namespace ORM
{
    public class Blog
    {
        public Blog()
        {
            Posts = new List<Post>();
        }

        public int BlogId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}