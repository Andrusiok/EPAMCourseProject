using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace ORM.Configuration
{
    public class BlogConfiguration : EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration()
        {
            HasKey(c => c.BlogId);
            HasOptional(e => e.User)
                .WithRequired(e=>e.Blog)
                .WillCascadeOnDelete(true);
            HasMany(e => e.Posts)
                .WithRequired(e => e.Blog)
                .WillCascadeOnDelete(false);
        }
    }
}
