using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities
{
    public class PostEntity:IBLLEntity, IEquatable<PostEntity>
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Annotation { get; set; }
        public string Text { get; set; }

        public bool Equals(PostEntity other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return (Id == other.Id && BlogId == other.BlogId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() == typeof(PostEntity)) return Equals((PostEntity)obj);
            else return false;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
