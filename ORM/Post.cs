using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM
{
    public class Post
    {
        public Post()
        {
            Likes = new List<Like>();
            Comments = new List<Comment>();
            Images = new List<Image>();
        }

        public int Id { get; set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }

        public string Title { get; set; }

        public string Annotation { get; set; }

        [MaxLength]
        public string Text { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        //public virtual ICollection<Tag> Tags { get; set; }
    }
}