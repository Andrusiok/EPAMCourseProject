using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace ORM.Configuration
{
    public class LikeConfiguration : EntityTypeConfiguration<Like>
    {
        public LikeConfiguration()
        {
            HasKey(e => e.Id);
        }
    }
}
