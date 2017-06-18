using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace ORM.Configuration
{
    public class CommentConfiguration:EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            HasKey(e => e.Id);
        }
    }
}
