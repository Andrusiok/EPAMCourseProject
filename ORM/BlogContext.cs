using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ORM.Configuration;

namespace ORM
{
    public class BlogContext:DbContext
    {
        static BlogContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public BlogContext(): base("name=CloudInfoDb") { }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new BlogConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new LikeConfiguration());
            modelBuilder.Configurations.Add(new ImageConfiguration());
        }
    }
}
