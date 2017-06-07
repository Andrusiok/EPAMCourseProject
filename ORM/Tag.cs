using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Tag
    {
        public Tag()
        {
            Posts = new List<Post>();
        }

        public int TagId { get; set; }

        public string TagName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
