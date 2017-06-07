using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace ORM.Configuration
{
    public class TagConfiguration: EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            HasKey(e => e.TagId);
        }
    }
}
