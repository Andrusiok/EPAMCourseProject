using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities
{
    public class BlogEntity : IBLLEntity, IEquatable<BlogEntity>
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public bool Equals(BlogEntity other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return (Id == other.Id && UserId == other.UserId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() == typeof(BlogEntity)) return Equals((BlogEntity)obj);
            else return false;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
