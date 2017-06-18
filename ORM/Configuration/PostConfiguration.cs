using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace ORM.Configuration
{
    public class PostConfiguration:EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            HasKey(e => e.Id);
            HasMany(e => e.Likes)
                .WithRequired(e => e.Post)
                .HasForeignKey(e=>e.PostId);
            HasMany(e => e.Comments)
                .WithRequired(e => e.Post)
                .HasForeignKey(e => e.PostId);
            HasMany(e => e.Images)
                .WithRequired(e => e.Post)
                .HasForeignKey(e => e.PostId);
        }
    }
}
